using OperationsManagement.Domain._Shared;
using OperationsManagement.Domain.Templates.Entities;

namespace OperationsManagement.Domain.Templates.Repositories;

public interface ITemplateRepository : IRepository<Template>
{
    Task<IReadOnlyCollection<Template>> GetAllAsync(CancellationToken cancellationToken);
    Task<Template?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
}
