using Domain.Common;

namespace Application.DTOs.Articles;

public class ArticleVm : BaseEntity
{
    public string Title { get; set; } = string.Empty;
    public string Body { get; set; } = string.Empty;
    public int Likes { get; set; } = 0;
}
