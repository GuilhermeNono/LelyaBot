using DSharpPlus.Entities;
using Lelya.Infra.Core.Pageable.Emoji;

namespace Lelya.Infra.Core.Pageable.Page;

public interface IPageOption
{
    public IPaginationEmoji Emojis { get; set; }
    public int CurrentPage { get; set; }
    public DiscordEmoji NextEmoji();
    public bool IsChangePage();
    public DiscordEmoji PreviousEmoji();
    public TimeSpan Timeout { get; set; }
    public int UpdateToNextPage();
    public int UpdateToPreviousPage();
    public void IncrementTotalPages();
    public void DecrementTotalPages();
    public Dictionary<string, DiscordEmoji> PageEmojis();
}