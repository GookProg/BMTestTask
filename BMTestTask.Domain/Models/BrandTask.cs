using BMTestTask.Domain.Enums;

namespace BMTestTask.Domain.Models;

public class BrandTask
{
    public Guid Id { get; set; }
    public BrandTaskStatus Status { get; set; }
    public DateTime Timestamp { get; set; }
}