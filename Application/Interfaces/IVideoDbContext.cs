using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces;

public interface IVideoDbContext
{
    DbSet<Domain.Entities.Video> VideoDbSet { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}