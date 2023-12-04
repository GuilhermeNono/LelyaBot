using DSharpPlus.Entities;
using Lelya.Infra.Core.Pageable.Emoji;

namespace Lelya.Infra.Core.Pageable;

public interface IPageableEmbed
{
    public void NextPage();
    public DiscordMessageBuilder GetCurrentEmbed();
    public bool IsChangePage();
    public void PreviousPage();
    public DiscordEmoji GetPageEmoji(EPageEmoji emoji);
    public Dictionary<string, DiscordEmoji> PageEmojis();
    public IEnumerable<DiscordMessageBuilder> GetEmbedContent();
    public void AddEmbedContent(DiscordMessageBuilder embedToInclude);
}