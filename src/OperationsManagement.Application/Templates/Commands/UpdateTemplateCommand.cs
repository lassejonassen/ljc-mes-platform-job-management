using OperationsManagement.Application.Templates.DTOs;
using OperationsManagement.Domain.Templates.Errors;
using OperationsManagement.Domain.Templates.Repositories;
using OperationsManagement.SharedKernel;
using OperationsManagement.SharedKernel.Messaging;

namespace OperationsManagement.Application.Templates.Commands;

public sealed record UpdateTemplateCommand(UpdateTemplateDTO Dto) : IRequest<Result>;

public sealed class UpdateTemplateCommandHandler(
    ITemplateRepository templateRepository,
    IUnitOfWork unitOfWork)
    : IRequestHandler<UpdateTemplateCommand, Result>
{
    public async Task<Result> Handle(UpdateTemplateCommand request, CancellationToken cancellationToken)
    {
        var entity = await templateRepository.GetByIdAsync(request.Dto.Id, cancellationToken);
        if (entity is null)
        {
            return Result.Failure(TemplateErrors.NotFound);
        }

        var result = entity.Update(request.Dto.Name, request.Dto.Description);
        if (result.IsFailure)
        {
            return Result.Failure(result.Error);
        }

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
