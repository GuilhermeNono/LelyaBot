using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity.Enums;
using DSharpPlus.Interactivity.Extensions;

namespace Commands.Util;

public class Help: BaseCommandModule
{
    [Command("help")]
    [Cooldown(5, 10, CooldownBucketType.User)]
    public async Task HelpCommand(CommandContext ctx)
    {
        IEnumerable<DiscordMessageBuilder> embedHelpMessage = new List<DiscordMessageBuilder>()
        {
            new DiscordMessageBuilder()
                .AddEmbed(new DiscordEmbedBuilder()
                    .WithTitle("**Ajuda ➔**")
                    .WithDescription(
                        "Olá sou seu bot focado na administração desse servidor. Eu ainda estou em desenvolvimento então erros ou bugs inesperados podem acontecer, no entanto, se caso acontecer, contate o desenvolvedor do bot.")
                    .WithThumbnail(
                        "https://media.discordapp.net/attachments/776094611470942208/885266085979512902/exclamation-xxl.png")
                    .AddField("Desenvolvedor 🠗 ", "g.nono")
                    .WithColor(new DiscordColor("#8e3deb"))),
            new DiscordMessageBuilder()
                .AddEmbed(new DiscordEmbedBuilder()
                    .WithTitle("**Teste ➔**")
                    .WithColor(new DiscordColor("#8e3deb")))
        };

        var interactivity = ctx.Client.GetInteractivity();
        
        var message = await ctx.RespondAsync(embedHelpMessage.First());
        
        await message.CreateReactionAsync(DiscordEmoji.FromName(ctx.Client, ":track_previous:"));
        await message.CreateReactionAsync(DiscordEmoji.FromName(ctx.Client, ":track_next:"));
        
        var result = await interactivity.WaitForReactionAsync(x =>
            x.Emoji == DiscordEmoji.FromName(ctx.Client, ":track_previous:"),
            ctx.User,
            TimeSpan.FromSeconds(60)
            );
        
        // O WaitForReactionAsync deixa de executar oque está abaixo dele até que a condição dentro dele
        // Seja verdadeira, ou caso o tempo acabe.
    }
}