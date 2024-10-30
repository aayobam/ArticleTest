using Application.DTOs.Articles;
using Application.Response;

namespace Application.Contracts.Persistence;

public interface IArticleRepository
{
    Task<GenericResponse> AllArticlesAsync();
    Task<ArticleVm> GetArticleByIdAsync(Guid id);
    Task<GenericResponse> LikeArticleAsync(Guid id);
}
