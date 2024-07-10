using BMTestTask.Domain.Enums;
using BMTestTask.Domain.Interfaces;
using BMTestTask.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BMTestTask.DataAccess.Postgre.Repositories;

public class BrandTaskRepository : IBrandTaskRepository
{
    private readonly BMTestTaskDbContext _context;

    public BrandTaskRepository(BMTestTaskDbContext context)
    {
        _context = context;
    }

    public async Task<BrandTask?> GetByIdAsync(Guid id)
    {
        return await _context.Tasks.FirstOrDefaultAsync(task => task.Id == id);
    }

    public async Task<Guid> CreateAsync()
    {
        var newTask = new BrandTask
        {
            Status = BrandTaskStatus.Created,
            Timestamp = DateTime.Now.ToUniversalTime()
        };

        _context.Tasks.Add(newTask);
        await _context.SaveChangesAsync();

        return newTask.Id;
    }

    public async Task UpdateAsync(Guid id, BrandTaskStatus status)
    {
        var task = await GetByIdAsync(id);
        task!.Status = status;
        task.Timestamp = DateTime.Now.ToUniversalTime();

        _context.Tasks.Update(task);
        await _context.SaveChangesAsync();
    }
}