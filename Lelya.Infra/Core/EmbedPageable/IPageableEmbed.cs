﻿using DSharpPlus.Entities;

namespace Lelya.Infra.Core.EmbedPageable;

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