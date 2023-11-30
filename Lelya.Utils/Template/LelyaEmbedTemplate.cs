using DSharpPlus.Entities;

namespace Lelya.Utils.Template;

public static class LelyaEmbedTemplate
{
    public static IEnumerable<DiscordMessageBuilder> HelpPages()
    {
        return new List<DiscordMessageBuilder>
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
    }
}