using DotNetEnv;
using Lelya.Infra.Database.Migration;

Env.Load();
var bot = new Bot.Bot();
bot.RunAsync().GetAwaiter().GetResult();