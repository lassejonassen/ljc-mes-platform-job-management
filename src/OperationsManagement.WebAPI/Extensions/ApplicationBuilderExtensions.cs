using Microsoft.EntityFrameworkCore;
using OperationsManagement.Infrastructure.Persistence.DbContexts;

namespace OperationsManagement.WebAPI.Extensions;

public static partial class ApplicationBuilderExtensions
{
    public static IApplicationBuilder MigrateDatabases(this IApplicationBuilder app)
    {
        using IServiceScope scope = app.ApplicationServices.CreateScope();

        scope.ServiceProvider
            .GetRequiredService<ApplicationDbContext>()
            .Database.Migrate();

        return app;
    }
}
