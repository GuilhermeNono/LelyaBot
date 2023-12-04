using DSharpPlus.Entities;
using Lelya.Infra.Core.Pageable.Emoji;

namespace Lelya.Infra.Core.Pageable.Page;

public class PageOption : IPageOption
{
    public int CurrentPage { get; set; } = 1;
    private int LastPage { get; set; } = 1;
    private int NextPage { get; set; } = 2;
    private int TotalPages { get; set; }
    public IPaginationEmoji Emojis { get; set; }

    public TimeSpan Timeout { get; set; }

    public PageOption(IPaginationEmoji emojis)
    {
        Emojis = emojis;
    }

    public void IncrementTotalPages()
    {
        TotalPages += 1;
    }
    
    public void DecrementTotalPages()
    {
        if (TotalPages <= 0)
            TotalPages = 0;
        
        TotalPages -= 1;
    }

    public DiscordEmoji NextEmoji()
    {
        return Emojis.NextEmoji;
    }

    public bool IsChangePage()
    {
        return LastPage != CurrentPage;
    }

    public DiscordEmoji PreviousEmoji()
    {
        return Emojis.PreviousEmoji;
    }
    
    public Dictionary<string, DiscordEmoji> PageEmojis()
    {
        return new Dictionary<string, DiscordEmoji>(new List<KeyValuePair<string, DiscordEmoji>>
        {
            new KeyValuePair<string, DiscordEmoji>("Next Emoji", NextEmoji()),
            new KeyValuePair<string, DiscordEmoji>("Previous Emoji", PreviousEmoji())
        });
    }

    public int UpdateToNextPage()
    {
        CurrentPage += 1;
        LastPage = CurrentPage - 1;
        NextPage = CurrentPage + 1;

        Validations();

        return CurrentPage;
    }

    public int UpdateToPreviousPage()
    {
        LastPage = CurrentPage;
        NextPage = CurrentPage;
        CurrentPage -= 1;


        Validations();

        return CurrentPage;
    }

    private void Validations()
    {
        if (CurrentPage > TotalPages)
            CurrentPage = TotalPages;

        if (NextPage > TotalPages)
            NextPage = TotalPages;

        if (LastPage <= 0)
            LastPage = 1;

        if (CurrentPage > 0) return;
        
        CurrentPage = 1;
        NextPage = CurrentPage + 1;
    }
}