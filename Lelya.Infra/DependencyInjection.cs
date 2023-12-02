﻿using Lelya.Infra.Core.EmbedPageable;
using Microsoft.Extensions.DependencyInjection;

namespace Lelya.Infra;

public static class DependencyInjection
{
    public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
    {
        services.AddScoped<IPageOption, PageOption>();
        services.AddScoped<IPageEmbed, PageEmbed>();
        services.AddScoped<IPaginationEmoji, PaginationEmoji>();
        return services;
    } 
}