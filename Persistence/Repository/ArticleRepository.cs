using Application.Contracts.Persistence;
using Application.DTOs.Articles;
using Application.Exceptions;
using Application.Response;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistence.DatabaseContexts;
using System.Net;

namespace Persistence.Repository;

public class ArticleRepository : IArticleRepository
{
    private readonly ILogger<ArticleRepository> _logger;
    private readonly ApplicationDbContext _context;

    public ArticleRepository(ILogger<ArticleRepository> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<GenericResponse> AllArticlesAsync()
    {
        _logger.LogInformation($"\n fetching all articles | {DateTimeOffset.Now} \n");

        var articles = await _context.Articles
            .AsNoTracking()
            .OrderByDescending(a => a.DateCreated)
            .Select(a => new ArticleVm
            {
                Id = a.Id,
                Title = a.Title,
                Body = a.Body,
                Likes = a.Likes,
            })
            .ToListAsync();

        return new GenericResponse()
        {
            Success = true,
            Message = "success",
            Data = articles,
            Status = HttpStatusCode.OK.ToString()
        };
    }

    public async Task<ArticleVm> GetArticleByIdAsync(Guid id)
    {
        _logger.LogInformation($"\n fetching article instance | {DateTimeOffset.Now} \n");

        var instance = await _context.Articles
            .AsNoTracking()
            .SingleOrDefaultAsync(a => a.Id == id);

        if (instance == null)
        {
            _logger.LogInformation($"\n article not found | {DateTimeOffset.Now} \n");
            throw new NotFoundException("article not found", HttpStatusCode.NotFound.ToString());
        }

        var article = new ArticleVm
        {
            Id = instance.Id,
            Body = instance.Body,
            Likes = instance.Likes,
        };
        return article;
    }

    public async Task<GenericResponse> LikeArticleAsync(Guid id)
    {
        var instance = await GetArticleByIdAsync(id);
       
        instance.Likes++;

        var model = new Article()
        {
            Id = instance.Id,
            Title = instance.Title,
            Body = instance.Body,
            Likes = instance.Likes,
        };

        _context.Articles.Update(model);
        await _context.SaveChangesAsync();

        _logger.LogInformation($"\n like added | {DateTimeOffset.Now} \n");

        return new GenericResponse()
        {
            Success = true,
            Message = "success",
            Data = instance,
            Status = HttpStatusCode.OK.ToString()
        };
    }
}
