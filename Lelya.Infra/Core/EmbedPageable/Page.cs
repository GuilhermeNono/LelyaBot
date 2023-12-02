using DSharpPlus.Entities;

namespace Lelya.Infra.Core.EmbedPageable;

public class Page
{
    public DiscordMessageBuilder Content { get; set; }

    public Page(DiscordMessageBuilder content)
    {
        Content = content;
    }
}