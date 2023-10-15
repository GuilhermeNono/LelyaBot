using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;

namespace Commands.Commands;

public class FunCommands : BaseCommandModule
{
    [Command("help")]
    [Cooldown(5, 10, CooldownBucketType.User)]
    public async Task HelpCommand(CommandContext ctx)
    {
        var embedHelpMessage = new DiscordMessageBuilder()
            .AddEmbed(new DiscordEmbedBuilder()
                .WithTitle("**Ajuda ➔**")
                .WithDescription(
                    "Olá sou seu bot focado na administração desse servidor. Eu ainda estou em desenvolvimento então erros ou bugs inesperados podem acontecer, no entanto, se caso acontecer, contate o desenvolvedor do bot.\"")
                .WithThumbnail(
                    "https://media.discordapp.net/attachments/776094611470942208/885266085979512902/exclamation-xxl.png")
                .AddField("Desenvolvedor 🠗 ", "g.nono")
                .WithColor(new DiscordColor("#8e3deb")));
        await ctx.Channel.SendMessageAsync(embedHelpMessage);
    }

    [Command("add")]
    [RequirePermissions(Permissions.Administrator)]
    public async Task Addition(CommandContext ctx, int number1, int number2)
    {
        var answer = number1 + number2;
        await ctx.Channel.SendMessageAsync(answer.ToString());
    }

    [Command("subtract")]
    [RequirePermissions(Permissions.Administrator)]
    public async Task Subtraction(CommandContext ctx, int number1, int number2)
    {
        var answer = number1 - number2;
        await ctx.Channel.SendMessageAsync(answer.ToString());
    }

    //Criando EmbedMessages e enviado para o canal que o comando foi invocado.
    [Command("embedmessage")]
    [RequirePermissions(Permissions.Administrator)]
    public async Task SendEmbedMessage(CommandContext ctx)
    {
        var embedMessage = new DiscordMessageBuilder()
            .AddEmbed(new DiscordEmbedBuilder()
                .WithTitle("This is a Title")
                .WithDescription("This is a description")
                .WithColor(DiscordColor.Aquamarine));

        await ctx.Channel.SendMessageAsync(embedMessage);
    }

    //Maneira simplificada de enviar um embed para um canal.
    [Command("embed")]
    [RequirePermissions(Permissions.Administrator)]
    public async Task SendEmbed(CommandContext ctx)
    {
        var embedMessage = new DiscordEmbedBuilder()
        {
            Title = "This is a Title",
            Description = "This is a description",
            Color = DiscordColor.Gold
        };

        await ctx.Channel.SendMessageAsync(embed: embedMessage);
    }
    
    
}