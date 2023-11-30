using System.Reflection;
using Commands.Fun;
using Commands.SlashCommands;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.CommandsNext.Exceptions;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity;
using DSharpPlus.Interactivity.Enums;
using DSharpPlus.Interactivity.Extensions;
using DSharpPlus.SlashCommands;

namespace Bot;

public class Bot
{
    private DiscordClient? Client { get; set; }
    private CommandsNextExtension? Commands { get; set; }

    public async Task RunAsync()
    {
        var config = ConfigureBot();

        Client?.UseInteractivity(new InteractivityConfiguration()
        {
            PollBehaviour = PollBehaviour.KeepEmojis,
            Timeout = TimeSpan.FromMinutes(2)
        });

        ConfigureCommands(config);

        await Client!.ConnectAsync();
        await Task.Delay(-1);
    }

    private static async Task OnCommandError(CommandsNextExtension sender, CommandErrorEventArgs e)
    {
        if (e.Exception is ChecksFailedException castedException)
        {
            var cooldownTimer = string.Empty;

            foreach (var check in castedException.FailedChecks)
            {
                var cooldown = (CooldownAttribute)check;
                var timeLeft = cooldown.GetRemainingCooldown(e.Context);

                cooldownTimer = timeLeft.ToString(@"hh\:mm\:ss");
            }

            var cooldownMessage = new DiscordEmbedBuilder()
            {
                Title = "Wait for the cooldown to End",
                Description = $"Remaining time: {cooldownTimer}",
                Color = DiscordColor.Red
            };

            await e.Context.Channel.SendMessageAsync(embed: cooldownMessage);
        }
    }

    private Config ConfigureBot()
    {
        var token = Environment.GetEnvironmentVariable("TOKEN") 
                    ?? throw new Exception("É necessario informar um token")!;
        var prefix = Environment.GetEnvironmentVariable("PREFIX")
            ?? throw new Exception("É necessario informar um prefixo")!;

        var config = new Config(token, prefix);

        var discordConfig = new DiscordConfiguration()
        {
            Intents = DiscordIntents.All,
            Token = config.Token,
            TokenType = TokenType.Bot,
            AutoReconnect = true,
        };

        Client = new DiscordClient(discordConfig);
        return config;
    }

    private void ConfigureCommands(Config config)
    {
        var commandsConfig = new CommandsNextConfiguration()
        {
            StringPrefixes = new string[] { config.Prefix },
            EnableMentionPrefix = true,
            EnableDms = false,
            EnableDefaultHelp = false
        };

        RegisterChatCommands(commandsConfig);
        RegisterSlashCommands();

        CommandErrorCheck();
    }

    private void CommandErrorCheck()
    {
        Commands!.CommandErrored += OnCommandError;
    }

    private void RegisterChatCommands(CommandsNextConfiguration config)
    {
        Commands = Client!.UseCommandsNext(config);

        Commands.RegisterCommands(Assembly.GetAssembly(typeof(FunCommands))!);
    }

    private void RegisterSlashCommands()
    {
        Client!.UseSlashCommands().RegisterCommands(Assembly.GetAssembly(typeof(FunSl))!, 466405222877495299);
    }
}