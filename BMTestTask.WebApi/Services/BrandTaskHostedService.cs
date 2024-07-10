using BMTestTask.Domain.Enums;
using BMTestTask.Domain.Interfaces;

namespace BMTestTask.WebApi.Services;

public class BrandTaskHostedService : IHostedService
{
    private readonly IServiceProvider _serviceProvider;
    private readonly TimeSpan _interval = TimeSpan.FromMinutes(2);

    public BrandTaskHostedService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task RunTask(Guid id)
    {
        using var scope = _serviceProvider.CreateScope();
        var repo = scope.ServiceProvider.GetRequiredService<IBrandTaskRepository>();

        await repo.UpdateAsync(id, BrandTaskStatus.Running);
        await Task.Delay(_interval);
        await repo.UpdateAsync(id, BrandTaskStatus.Finished);
    }

    public Task StartAsync(CancellationToken cancellationToken) => Task.CompletedTask;

    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}