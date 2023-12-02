using DSharpPlus.Entities;

namespace Lelya.Infra.Core.EmbedPageable;

public interface IPaginationEmoji
{
    public DiscordEmoji NextEmoji { get; set; }
    public DiscordEmoji PreviousEmoji { get; set; }

}