using BMTestTask.DataAccess.Postgre.Repositories;
using BMTestTask.Domain.Interfaces;
using BMTestTask.WebApi.Services;

namespace BMTestTask.WebApi.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        if (services == null)
        {
            throw new ArgumentNullException(nameof(services));
        }

        services.AddScoped<IBrandTaskRepository, BrandTaskRepository>();

        return services;
    }

    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        if (services is null)
        {
            throw new ArgumentNullException(nameof(services));
        }

        services.AddSingleton<BrandTaskHostedService>();
        services.AddHostedService(provider => provider.GetRequiredService<BrandTaskHostedService>());
        services.AddScoped<IBrandTaskService, BrandTaskService>();

        return services;
    }
}