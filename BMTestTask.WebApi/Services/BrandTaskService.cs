using BMTestTask.Domain.Interfaces;
using BMTestTask.Domain.Models;

namespace BMTestTask.WebApi.Services;

public class BrandTaskService : IBrandTaskService
{
    private readonly IBrandTaskRepository _repo;
    private readonly BrandTaskHostedService _hostedService;

    public BrandTaskService(IBrandTaskRepository repo, BrandTaskHostedService hostedService)
    {
        _repo = repo;
        _hostedService = hostedService;
    }

    public async Task<Guid> PostAsync()
    {
        var id = await _repo.CreateAsync();
        _hostedService.RunTask(id);

        return id;
    }

    public async Task<BrandTask?> GetAsync(Guid id)
    {
        return await _repo.GetByIdAsync(id);
    }
}