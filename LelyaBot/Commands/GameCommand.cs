using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using LelyaBot.External_Classes;

namespace LelyaBot.Commands;

public class GameCommand: BaseCommandModule
{
    [Command("cardgame")]
    public async Task SimpleCardGame(CommandContext ctx)
    {
        try
        {
            var userCard = new CardBuilder();
            var userCardMessage = new DiscordMessageBuilder()
                .AddEmbed(new DiscordEmbedBuilder()

                    .WithColor(DiscordColor.Aquamarine)
                    .WithTitle("Your Card")
                    .WithDescription($"You drew a: {userCard.SelectedCard}"));

            await ctx.Channel.SendMessageAsync(userCardMessage);

            var botCard = new CardBuilder();
            var botCardMessage = new DiscordMessageBuilder()
                .AddEmbed(new DiscordEmbedBuilder()

                    .WithColor(DiscordColor.Cyan)
                    .WithTitle("Bot Card")
                    .WithDescription($"The bot drew a: {botCard.SelectedCard}"));

            await ctx.Channel.SendMessageAsync(botCardMessage);

            var resultMessage = new DiscordEmbedBuilder();

            if (userCard.SelectedNumber > botCard.SelectedNumber)
            {
                // The user wins
                resultMessage.Title = "**You win the game!!**";
                resultMessage.Color = DiscordColor.Green;
            }
            else
            {
                // The Bot wins
                resultMessage.Title = "**You lose the game!!**";
                resultMessage.Color = DiscordColor.Red;
            }

            await ctx.Channel.SendMessageAsync(resultMessage);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}