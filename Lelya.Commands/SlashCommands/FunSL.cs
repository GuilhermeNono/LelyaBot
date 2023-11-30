using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using DSharpPlus.SlashCommands.Attributes;

namespace Commands.SlashCommands;

public class FunSl : ApplicationCommandModule
{
    [SlashCommand("test2", "test")]
    [SlashRequirePermissions(Permissions.Administrator)]
    public async Task Teste2SlashCommand(InteractionContext ctx)
    {
        await ctx.Channel.SendMessageAsync("foi");
    }
    
    
    [SlashCommand("test", "This is the first slash command of bot")]
    [SlashRequirePermissions(Permissions.Administrator)]
    public async Task TestSlashCommand(InteractionContext ctx, [Choice("Gui", "nono")][Option("user", "user of server")] string user)
    {
        await ctx.CreateResponseAsync(InteractionResponseType.DeferredChannelMessageWithSource);

        var embedMessage = new DiscordEmbedBuilder()
        {
            Title = "test",
            Description = user
        };

        await ctx.EditResponseAsync(new DiscordWebhookBuilder().WithContent("Thanks for waiting!"));

        await ctx.Channel.SendMessageAsync(embed: embedMessage);
    }

    // [SlashCommand("pool", "pool")]
    // public async Task PoolCommand(InteractionContext ctx,
    //     [Option("question", "The main pool question")]
    //     string question,
    //     [Option("timeLimit", "The time set at this pool")]
    //     long timeLimit,
    //     [Option("option1", "Option 1")] string optionOne,
    //     [Option("option1", "Option 1")] string optionTwo,
    //     [Option("option1", "Option 1")] string optionThree,
    //     [Option("option1", "Option 1")] string optionFour)
    // {
    //     var interactivity = ctx.Client.GetInteractivity();
    //     var timer = TimeSpan.FromSeconds(timeLimit);
    //
    //     DiscordEmoji[] optionEmojis =
    //     {
    //         DiscordEmoji.FromName(ctx.Client, ":one:", false),
    //         DiscordEmoji.FromName(ctx.Client, ":two:", false),
    //         DiscordEmoji.FromName(ctx.Client, ":three:", false),
    //         DiscordEmoji.FromName(ctx.Client, ":four:", false)
    //     };
    //
    //     string optionsString = optionEmojis[0] + " | " + optionOne + "\n" +
    //                            optionEmojis[1] + " | " + optionTwo + "\n" +
    //                            optionEmojis[2] + " | " + optionThree + "\n" +
    //                            optionEmojis[3] + " | " + optionFour + "\n";
    //
    //     var poolMessage = new DiscordMessageBuilder()
    //         .AddEmbed(new DiscordEmbedBuilder()
    //             .WithColor(DiscordColor.Rose)
    //             .WithTitle(string.Join(" ", question))
    //             .WithDescription(optionsString));
    //
    //     var putReactOn = await ctx.Channel.SendMessageAsync(poolMessage);
    //     foreach (var emoji in optionEmojis)
    //     {
    //         await putReactOn.CreateReactionAsync(emoji);
    //     }
    //
    //     var result = await interactivity.CollectReactionsAsync(putReactOn, timer);
    //
    //     int count1 = 0;
    //     int count2 = 0;
    //     int count3 = 0;
    //     int count4 = 0;
    //
    //     foreach (var react in result)
    //     {
    //         if (react.Emoji == optionEmojis[0])
    //         {
    //             count1++;
    //         }
    //
    //         if (react.Emoji == optionEmojis[1])
    //         {
    //             count2++;
    //         }
    //         if (react.Emoji == optionEmojis[2])
    //         {
    //             count3++;
    //         }
    //
    //         if (react.Emoji == optionEmojis[3])
    //         {
    //             count4++;
    //         }
    //     }
    //
    //     int totalVotes = count1 + count2 + count3 + count4;
    //
    //     string resultString = optionEmojis[0] + ": " + count1 + " Votes \n" +
    //                           optionEmojis[1] + ": " + count2 + " Votes \n" +
    //                           optionEmojis[2] + ": " + count3 + " Votes \n" +
    //                           optionEmojis[3] + ": " + count4 + " Votes \n";
    //
    //     var resultMessage = new DiscordMessageBuilder()
    //         .AddEmbed(new DiscordEmbedBuilder()
    //             .WithColor(DiscordColor.Green)
    //             .WithTitle("Result of pool")
    //             .WithDescription(resultString));
    //
    //     await ctx.Channel.SendMessageAsync(resultMessage);
    // }
}