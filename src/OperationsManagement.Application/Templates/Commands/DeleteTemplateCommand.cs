using OperationsManagement.Domain.Templates.Errors;
using OperationsManagement.Domain.Templates.Repositories;
using OperationsManagement.SharedKernel;
using OperationsManagement.SharedKernel.Messaging;

namespace OperationsManagement.Application.Templates.Commands;

public sealed record DeleteTemplateCommand(Guid Id) : IRequest<Result>;

public sealed class DeleteTemplateCommandHandler(
    ITemplateRepository templateRepository,
    IUnitOfWork unitOfWork)
    : IRequestHandler<DeleteTemplateCommand, Result>
{
    public async Task<Result> Handle(DeleteTemplateCommand request, CancellationToken cancellationToken)
    {
        var entity = await templateRepository.GetByIdAsync(request.Id, cancellationToken);
        if (entity is null)
        {
            return Result.Failure(TemplateErrors.NotFound);
        }

        templateRepository.Delete(entity);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
