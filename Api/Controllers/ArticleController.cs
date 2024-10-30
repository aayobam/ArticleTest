using Application.Contracts.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleRepository _articleRepository;

        public ArticleController(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        [HttpGet("{id}/get-article")]
        public async Task<IActionResult> GetArticle(Guid id)
        {
            var result = await _articleRepository.GetArticleByIdAsync(id);
            return Ok(result);
        }

        [HttpGet("{id}/like-article")]
        public async Task<IActionResult> LikeArticle(Guid id)
        {
            var result = await _articleRepository.LikeArticleAsync(id);
            return Ok(result);
        }

        [HttpGet("all-articles")]
        public async Task<IActionResult> AllArticles()
        {
            var result = await _articleRepository.AllArticlesAsync();
            return Ok(result);
        }
    }
}
