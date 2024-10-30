using Domain.Common;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.DatabaseContexts;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Article>()
           .HasData(
            new Article { Id = Guid.NewGuid(), Title = "Article 1", Body = "Body of Article 1", Likes = 0 },
            new Article { Id = Guid.NewGuid(), Title = "Article 2", Body = "Body of Article 2", Likes = 0 },
            new Article { Id = Guid.NewGuid(), Title = "Article 3", Body = "Body of Article 3", Likes = 0 },
            new Article { Id = Guid.NewGuid(), Title = "Article 4", Body = "Body of Article 4", Likes = 0 },
            new Article { Id = Guid.NewGuid(), Title = "Article 5", Body = "Body of Article 5", Likes = 0 },
            new Article { Id = Guid.NewGuid(), Title = "Article 6", Body = "Body of Article 6", Likes = 0 },
            new Article { Id = Guid.NewGuid(), Title = "Article 7", Body = "Body of Article 7", Likes = 0 },
            new Article { Id = Guid.NewGuid(), Title = "Article 8", Body = "Body of Article 8", Likes = 0 },
            new Article { Id = Guid.NewGuid(), Title = "Article 9", Body = "Body of Article 9", Likes = 0 },
            new Article { Id = Guid.NewGuid(), Title = "Article 10", Body = "Body of Article 10", Likes = 0 }
            );
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in base.ChangeTracker.Entries<BaseEntity>().Where(q => q.State == EntityState.Added || q.State == EntityState.Modified))
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.DateCreated = DateTimeOffset.Now;
            }
            entry.Entity.DateModified = DateTimeOffset.Now;
        }

        return base.SaveChangesAsync(cancellationToken);
    }

    public DbSet<Article> Articles { get; set; }
}
