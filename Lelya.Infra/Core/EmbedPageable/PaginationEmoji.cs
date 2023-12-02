using DSharpPlus.Entities;

namespace Lelya.Infra.Core.EmbedPageable;

public class PaginationEmoji: IPaginationEmoji
{
    public DiscordEmoji NextEmoji { get; set; }
    public DiscordEmoji PreviousEmoji { get; set; }

    public PaginationEmoji()
    {
        NextEmoji = DiscordEmoji.FromUnicode("⏭");
        PreviousEmoji = DiscordEmoji.FromUnicode("⏮");
    }

    public PaginationEmoji(DiscordEmoji nextEmoji, DiscordEmoji previousEmoji)
    {
        NextEmoji = nextEmoji;
        PreviousEmoji = previousEmoji;
    }
}