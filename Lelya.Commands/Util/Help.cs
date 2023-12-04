using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.EventArgs;
using DSharpPlus.Interactivity.Extensions;
using Lelya.Infra.Core.Pageable;
using Lelya.Infra.Core.Pageable.Emoji;
using Lelya.Utils.Template;

namespace Commands.Util;

[ModuleLifespan(ModuleLifespan.Transient)]
public class Help : BaseCommandModule
{
    private readonly IPageableEmbed _pageableEmbed;

    public Help(IPageableEmbed pageableEmbed)
    {
        _pageableEmbed = pageableEmbed;
    }


    [Command("help")]
    [Cooldown(5, 10, CooldownBucketType.User)]
    public async Task HelpCommand(CommandContext ctx)
    {
        var loop = true;

        foreach (var embed in LelyaEmbedTemplate.HelpPages().ToList())
            _pageableEmbed.AddEmbedContent(embed);

        var interactivity = ctx.Client.GetInteractivity();

        var message = await ctx.RespondAsync(_pageableEmbed.GetEmbedContent().First());

        await message.CreateReactionAsync(_pageableEmbed.GetPageEmoji(EPageEmoji.Previous));
        await message.CreateReactionAsync(_pageableEmbed.GetPageEmoji(EPageEmoji.Next));

        while (loop)
        {
            var result = await interactivity.WaitForReactionAsync(x =>
                    x.Emoji == _pageableEmbed.GetPageEmoji(EPageEmoji.Previous) ||
                    x.Emoji == _pageableEmbed.GetPageEmoji(EPageEmoji.Next),
                ctx.User,
                TimeSpan.FromSeconds(60)
            );

            await UpdatePage(result.Result);
            await ModifyMessageToChangedPage(message);

            if (result.TimedOut)
                loop = false;
        }
    }

    private async Task ModifyMessageToChangedPage(DiscordMessage message)
    {
        if (_pageableEmbed.IsChangePage())
            await message.ModifyAsync(_pageableEmbed.GetCurrentEmbed());
    }

    private async Task UpdatePage(MessageReactionAddEventArgs messageArgs)
    {
        if (messageArgs.Emoji == _pageableEmbed.GetPageEmoji(EPageEmoji.Next))
            await UpdateEmbedEmoji(messageArgs, _pageableEmbed.GetPageEmoji(EPageEmoji.Next));
        else
            await UpdateEmbedEmoji(messageArgs, _pageableEmbed.GetPageEmoji(EPageEmoji.Previous));
    }

    private async Task UpdateEmbedEmoji(MessageReactionAddEventArgs messageArgs, DiscordEmoji emojiPage)
    {
        EmojiPageAction(emojiPage);
        await messageArgs.Message.DeleteReactionAsync(emojiPage,
            messageArgs.User);
    }

    private void EmojiPageAction(DiscordEmoji emoji)
    {
        if (emoji == _pageableEmbed.GetPageEmoji(EPageEmoji.Next))
            _pageableEmbed.NextPage();
        else
            _pageableEmbed.PreviousPage();
    }
}