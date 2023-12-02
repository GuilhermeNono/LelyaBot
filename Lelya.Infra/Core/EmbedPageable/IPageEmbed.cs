using DSharpPlus.Entities;

namespace Lelya.Infra.Core.EmbedPageable;

public interface IPageEmbed
{
    public PageEmbed NextPage();
    public DiscordMessageBuilder GetCurrentEmbed();
    public bool IsChangePage();
    public PageEmbed PreviousPage();
    public DiscordEmoji NextPageEmoji();
    public DiscordEmoji PreviousPageEmoji();
    public Dictionary<string, DiscordEmoji> PageEmojis();
    public IEnumerable<DiscordMessageBuilder> GetEmbedContent();
    public IEnumerable<DiscordMessageBuilder> AddEmbedContent(DiscordMessageBuilder embedToInclude);
}