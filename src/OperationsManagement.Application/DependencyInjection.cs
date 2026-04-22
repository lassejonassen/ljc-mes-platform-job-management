using Microsoft.Extensions.DependencyInjection;
using OperationsManagement.SharedKernel.Messaging;

namespace OperationsManagement.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatorHandlers(typeof(DependencyInjection).Assembly);

        return services;
    }
}