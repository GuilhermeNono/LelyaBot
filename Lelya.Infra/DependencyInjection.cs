﻿using Lelya.Infra.Core.Pageable;
using Lelya.Infra.Core.Pageable.Emoji;
using Lelya.Infra.Core.Pageable.Page;
using Microsoft.Extensions.DependencyInjection;

namespace Lelya.Infra;

public static class DependencyInjection
{
    public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
    {
        services.AddScoped<IPageOption, PageOption>();
        services.AddScoped<IPageableEmbed, PageableEmbed>();
        services.AddScoped<IPaginationEmoji, PaginationEmoji>();
        return services;
    } 
}