using OperationsManagement.Application;
using OperationsManagement.Infrastructure;
using OperationsManagement.WebAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.AddDefaults(string.Empty);

builder.Services.AddApplication();
builder.AddInfrastructure();

var app = builder.Build();

app.MapControllers();
app.UseDefaults();

app.Run();