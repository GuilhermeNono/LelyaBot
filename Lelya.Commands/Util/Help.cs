using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.EventArgs;
using DSharpPlus.Interactivity;
using DSharpPlus.Interactivity.Extensions;
using Lelya.Utils.Template;

namespace Commands.Util;

public class Help : BaseCommandModule
{

    private DiscordEmoji? _previousEmoji;
    private DiscordEmoji? _nextEmoji;
    private int _currentPosition = 0;
    private int _lastPosition = 0;

    [Command("help")]
    [Cooldown(5, 10, CooldownBucketType.User)]
    public async Task HelpCommand(CommandContext ctx)
    {
        InitProp(ctx);
        var embedHelpMessage = LelyaEmbedTemplate.HelpPages().ToList();
        var loop = true;
        
        var interactivity = ctx.Client.GetInteractivity();
        
        var message = await ctx.RespondAsync(embedHelpMessage[0]);

        await message.CreateReactionAsync(_previousEmoji);
        await message.CreateReactionAsync(_nextEmoji);

        //TODO 30-11-2023 | 10:40: Desenvolver classe responsavel por criar uma paginação para o help

        while (loop)
        {
            var result = await interactivity.WaitForReactionAsync(x =>
                    x.Emoji == _previousEmoji ||
                    x.Emoji == _nextEmoji,
                ctx.User,
                TimeSpan.FromSeconds(5)
            );

            if (result.Result.Emoji == _previousEmoji)
                await UpdatePreviousEmbedPosition(result);

            if (result.Result.Emoji == _nextEmoji)
                await UpdateNextEmbedPosition(embedHelpMessage, result);
            
            if (_lastPosition != _currentPosition)
                await message.ModifyAsync(embedHelpMessage.ElementAtOrDefault(_currentPosition)!);

            if (result.TimedOut)
                loop = false;
        }
    }

    private void InitProp(CommandContext ctx)
    {
        _previousEmoji = DiscordEmoji.FromName(ctx.Client, ":track_previous:");
        _nextEmoji = DiscordEmoji.FromName(ctx.Client, ":track_next:");
    }

    private async Task UpdateNextEmbedPosition(IList<DiscordMessageBuilder> embedHelpMessage, InteractivityResult<MessageReactionAddEventArgs> interactivityResult)
    {
        if (embedHelpMessage.Count - 1 != _currentPosition)
        {
            _lastPosition = _currentPosition;
            _currentPosition += 1;
        }

        await interactivityResult.Result.Message.DeleteReactionAsync(_nextEmoji, interactivityResult.Result.User);
    } 
    
    private async Task UpdatePreviousEmbedPosition(InteractivityResult<MessageReactionAddEventArgs> interactivityResult)
    {
        if (_currentPosition != 0)
        {
            _lastPosition = _currentPosition;
            _currentPosition -= 1;
        }

        await interactivityResult.Result.Message.DeleteReactionAsync(_previousEmoji, interactivityResult.Result.User);
    }
}