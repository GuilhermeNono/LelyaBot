using DotNetEnv;

Env.Load();
var bot = new Bot.Bot();
bot.RunAsync().GetAwaiter().GetResult();