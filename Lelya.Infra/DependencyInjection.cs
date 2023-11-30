using Lelya.Domain.Core;
using Lelya.Infra.Core.Teste;
using Microsoft.Extensions.DependencyInjection;

namespace Lelya.Infra;

public static class DependencyInjection
{
    public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
    {
        services.AddScoped<ITest, Teste>();
        return services;
    } 
}