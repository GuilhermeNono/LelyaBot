using DSharpPlus.Entities;

namespace Lelya.Infra.Core.Pageable.Emoji;

public interface IPaginationEmoji
{
    public DiscordEmoji NextEmoji { get; set; }
    public DiscordEmoji PreviousEmoji { get; set; }

}