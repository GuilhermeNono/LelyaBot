using DSharpPlus.Entities;

namespace Lelya.Infra.Core.EmbedPageable;

public class PageEmbed: IPageEmbed
{
    public IPageOption PageOption { get; set; }
    public IList<Page> Pages { get; set; }

    public PageEmbed(IPageOption pageOption, IList<Page> pages)
    {
        PageOption = pageOption;
        Pages = pages;
    }

    public DiscordMessageBuilder GetCurrentEmbed()
    {
        return GetEmbedContent().ElementAtOrDefault(PageOption.CurrentPage)!;
    }

    public bool IsChangePage()
    {
        return PageOption.IsChangePage();
    }

    public IEnumerable<DiscordMessageBuilder> GetEmbedContent()
    {
        PageOption.IncrementTotalPages();
        return Pages.Select(x => x.Content);
    }

    public Dictionary<string, DiscordEmoji> PageEmojis()
    {
        return PageOption.PageEmojis();
    }

    public DiscordEmoji NextPageEmoji()
    {
        return PageOption.NextEmoji();
    }
    
    public DiscordEmoji PreviousPageEmoji()
    {
        return PageOption.PreviousEmoji();
    }

    public IEnumerable<DiscordMessageBuilder> AddEmbedContent(DiscordMessageBuilder embedToInclude)
    {
        Pages.Add(new Page(embedToInclude));
        return GetEmbedContent();
    }

    public PageEmbed NextPage()
    {
        PageOption.UpdateToNextPage();
        return this;
    }

    public PageEmbed PreviousPage()
    {
        PageOption.UpdateToPreviousPage();
        return this;
    }
}