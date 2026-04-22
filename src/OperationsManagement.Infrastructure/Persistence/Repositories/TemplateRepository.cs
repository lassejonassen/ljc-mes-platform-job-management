using CleanArchitecture.Infrastructure.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;
using OperationsManagement.Domain.Templates.Entities;
using OperationsManagement.Domain.Templates.Repositories;

namespace CleanArchitecture.Infrastructure.Persistence.Repositories;

internal sealed class TemplateRepository(ApplicationDbContext context)
    : BaseRepository<Template>(context), ITemplateRepository
{
    public async Task<IReadOnlyCollection<Template>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await DbContext.Set<Template>().ToListAsync(cancellationToken);
    }

    public async Task<Template?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await DbContext.Set<Template>().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }
}
