using Domain.Common;

namespace Domain.Entities;

public class Article : BaseEntity
{
    public string Title { get; set; } = string.Empty;
    public string Body { get; set; } = string.Empty;
    public int Likes { get; set; } = 0;
}
