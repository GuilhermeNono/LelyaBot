using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.EventArgs;
using DSharpPlus.Interactivity;
using DSharpPlus.Interactivity.Extensions;
using Lelya.Infra.Core.EmbedPageable;
using Lelya.Utils.Template;

namespace Commands.Util;

[ModuleLifespan(ModuleLifespan.Transient)]
public class Help : BaseCommandModule
{

    private readonly IPageEmbed _embedPagination;

    public Help(IPageEmbed embedPagination)
    {
        _embedPagination = embedPagination;
    }


    [Command("help")]
    [Cooldown(5, 10, CooldownBucketType.Global)]
    public async Task HelpCommand(CommandContext ctx)
    {
        var loop = true;
        
        foreach (var embed in LelyaEmbedTemplate.HelpPages().ToList())
        {
            _embedPagination.AddEmbedContent(embed);
        }
        
        var interactivity = ctx.Client.GetInteractivity();
        
        var message = await ctx.RespondAsync(_embedPagination.GetEmbedContent().First());

        await message.CreateReactionAsync(_embedPagination.PreviousPageEmoji());
        await message.CreateReactionAsync(_embedPagination.NextPageEmoji());

        //TODO 30-11-2023 | 10:40: Desenvolver classe responsavel por criar uma paginação para o help

        while (loop)
        {
            var result = await interactivity.WaitForReactionAsync(x =>
                    x.Emoji == _embedPagination.PreviousPageEmoji() ||
                    x.Emoji == _embedPagination.NextPageEmoji(),
                ctx.User,
                TimeSpan.FromSeconds(5)
            );

            if (result.Result.Emoji == _embedPagination.PreviousPageEmoji())
                await UpdatePreviousEmbedPosition(result);

            if (result.Result.Emoji == _embedPagination.NextPageEmoji())
                await UpdateNextEmbedPosition(result);
            
            if (_embedPagination.IsChangePage())
                await message.ModifyAsync(_embedPagination.GetCurrentEmbed());

            if (result.TimedOut)
                loop = false;
        }
    }
    
    private async Task UpdateNextEmbedPosition(InteractivityResult<MessageReactionAddEventArgs> interactivityResult)
    {
        _embedPagination.NextPage();
        await interactivityResult.Result.Message.DeleteReactionAsync(_embedPagination.NextPageEmoji(), interactivityResult.Result.User);
    } 
    
    private async Task UpdatePreviousEmbedPosition(InteractivityResult<MessageReactionAddEventArgs> interactivityResult)
    {
        _embedPagination.PreviousPage();
        await interactivityResult.Result.Message.DeleteReactionAsync(_embedPagination.PreviousPageEmoji(), interactivityResult.Result.User);
    }
}