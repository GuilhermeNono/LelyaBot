using DSharpPlus.Entities;
using Lelya.Infra.Core.Pageable.Emoji;
using Lelya.Infra.Core.Pageable.Page;

namespace Lelya.Infra.Core.Pageable;

public class PageableEmbed : IPageableEmbed
{
    private IPageOption PageOption { get; set; }
    private readonly List<Page.Page> _pages = new();

    public PageableEmbed(IPageOption pageOption)
    {
        PageOption = pageOption;
    }

    public DiscordMessageBuilder GetCurrentEmbed()
    {
        return GetEmbedContent().ElementAtOrDefault(PageOption.CurrentPage - 1)!;
    }

    public bool IsChangePage()
    {
        return PageOption.IsChangePage();
    }

    public IEnumerable<DiscordMessageBuilder> GetEmbedContent()
    {
        return _pages.Select(x => x.Content);
    }

    public Dictionary<string, DiscordEmoji> PageEmojis()
    {
        return PageOption.PageEmojis();
    }

    public DiscordEmoji GetPageEmoji(EPageEmoji emoji)
    {
        return emoji == EPageEmoji.Next ? PageOption.NextEmoji() : PageOption.PreviousEmoji();
    }

    public void AddEmbedContent(DiscordMessageBuilder embedToInclude)
    {
        PageOption.IncrementTotalPages();
        _pages.Add(new Page.Page(embedToInclude));
    }

    public void NextPage()
    {
        PageOption.UpdateToNextPage();
    }

    public void PreviousPage()
    {
        PageOption.UpdateToPreviousPage();
    }
}