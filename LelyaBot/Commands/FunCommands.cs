using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;

namespace LelyaBot.Commands;

public class FunCommands : BaseCommandModule
{
    [Command("test")]
    public async Task TestCommand(CommandContext ctx)
    {
        Console.WriteLine("Working!");
        await ctx.Channel.SendMessageAsync("Hello");
    }

    [Command("add")]
    public async Task Addition(CommandContext ctx, int number1, int number2)
    {
        var answer = number1 + number2;
        await ctx.Channel.SendMessageAsync(answer.ToString());
    }

    [Command("subtract")]
    public async Task Subtraction(CommandContext ctx, int number1, int number2)
    {
        var answer = number1 - number2;
        await ctx.Channel.SendMessageAsync(answer.ToString());
    }

    //Criando EmbedMessages e enviado para o canal que o comando foi invocado.
    [Command("embedmessage")]
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