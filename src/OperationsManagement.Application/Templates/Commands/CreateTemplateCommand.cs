using OperationsManagement.Application.Templates.DTOs;
using OperationsManagement.Domain.Templates.Entities;
using OperationsManagement.Domain.Templates.Repositories;
using OperationsManagement.SharedKernel;
using OperationsManagement.SharedKernel.Messaging;

namespace OperationsManagement.Application.Templates.Commands;

public sealed record CreateTemplateCommand(CreateTemplateDTO Dto) : IRequest<Result<Guid>>;

public sealed class CreateTemplateCommandHandler(
    ITemplateRepository templateRepository,
    IUnitOfWork unitOfWork,
    IDateTimeProvider dateTimeProvider)
    : IRequestHandler<CreateTemplateCommand, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(CreateTemplateCommand request, CancellationToken cancellationToken)
    {
        var entity = Template.Create(request.Dto.Name, request.Dto.Description, dateTimeProvider.UtcNow);

        if (entity.IsFailure)
            return Result.Failure<Guid>(entity.Error);


        templateRepository.Add(entity.Value);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(entity.Value.Id);
    }
}
