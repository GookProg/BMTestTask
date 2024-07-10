using BMTestTask.Domain.Models;

namespace BMTestTask.Domain.Interfaces;

public interface IBrandTaskService
{
    Task<Guid> PostAsync();
    Task<BrandTask?> GetAsync(Guid id);
}