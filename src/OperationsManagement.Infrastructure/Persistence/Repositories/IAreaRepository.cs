using Microsoft.EntityFrameworkCore;
using OperationsManagement.Domain.Assets.Aggregates;
using OperationsManagement.Domain.Assets.Repositories;
using OperationsManagement.Infrastructure.Persistence.DbContexts;

namespace OperationsManagement.Infrastructure.Persistence.Repositories;

internal sealed class AreaRepository(ApplicationDbContext context)
     : Repository<Area>(context), IAreaRepository
{
    public async Task<IReadOnlyCollection<Area>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await DbContext.Set<Area>().ToListAsync(cancellationToken);
    }

    public async Task<Area?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await DbContext.Set<Area>()
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<bool> IsNameUniqueAsync(string name, CancellationToken cancellationToken)
    {
        return !await DbContext.Set<Area>().AnyAsync(x => x.Name == name, cancellationToken);
    }
}
