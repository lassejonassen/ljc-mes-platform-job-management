using OperationsManagement.Domain.Assets.Aggregates;
using OperationsManagement.Domain.Assets.Errors;
using OperationsManagement.Domain.Assets.Repositories;
using OperationsManagement.SharedKernel;
using OperationsManagement.SharedKernel.Messaging;
using System;
using System.Collections.Generic;
using System.Text;

namespace OperationsManagement.Application.Assets.Areas.Commands;

public sealed record CreateAreaCommand(Guid SiteId, string Name, string? Description) : IRequest<Result<Guid>>;

public sealed class CreateAreaCommandHandler(
    IAreaRepository repository,
    IUnitOfWork unitOfWork,
    IDateTimeProvider dateTimeProvider)
    : IRequestHandler<CreateAreaCommand, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(CreateAreaCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
        //var isSkuUnique = await repository.IsNameUniqueAsync(request.Name, cancellationToken);

        //if (!isSkuUnique)
        //    return Result.Failure<Guid>(SiteErrors.AlreadyExists);

        //var site = Site.Create(request.Name, request.Description, dateTimeProvider.UtcNow);

        //if (site.IsFailure)
        //    return Result.Failure<Guid>(site.Error);

        //repository.Add(site.Value);

        //await unitOfWork.SaveChangesAsync(cancellationToken);

        //return Result.Success(site.Value.Id);
    }
}