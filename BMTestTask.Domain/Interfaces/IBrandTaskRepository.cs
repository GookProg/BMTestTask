using BMTestTask.Domain.Enums;
using BMTestTask.Domain.Models;

namespace BMTestTask.Domain.Interfaces;

public interface IBrandTaskRepository
{
    Task<BrandTask?> GetByIdAsync(Guid id);
    Task<Guid> CreateAsync();
    Task UpdateAsync(Guid id, BrandTaskStatus status);
}