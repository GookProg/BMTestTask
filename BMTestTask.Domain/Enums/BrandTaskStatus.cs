using System.ComponentModel.DataAnnotations;

namespace BMTestTask.Domain.Enums;

public enum BrandTaskStatus : byte
{
    [Display(Name = "created")]
    Created = 1,
    [Display(Name = "running")]
    Running = 2,
    [Display(Name = "finished")]
    Finished = 3
}