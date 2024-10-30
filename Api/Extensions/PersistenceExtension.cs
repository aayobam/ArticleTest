using Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;
using Persistence.DatabaseContexts;
using Persistence.Repository;

namespace Persistence.Extensions;

public static class PersistenceExtension
{
    public static IServiceCollection AddPersistenceRegistration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IArticleRepository, ArticleRepository>();

        return services;
    }
}
