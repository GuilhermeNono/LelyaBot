using DSharpPlus.Entities;

namespace Lelya.Infra.Core.EmbedPageable;

public class PageableEmbed : IPageableEmbed
{
    private IPageOption PageOption { get; set; }
    private readonly List<Page> _pages = new();

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
        return emoji == EPageEmoji.NEXT ? PageOption.NextEmoji() : PageOption.PreviousEmoji();
    }

    public void AddEmbedContent(DiscordMessageBuilder embedToInclude)
    {
        PageOption.IncrementTotalPages();
        _pages.Add(new Page(embedToInclude));
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