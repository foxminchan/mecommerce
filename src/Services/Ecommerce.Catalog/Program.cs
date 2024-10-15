using Ecommerce.Catalog.Grpc;

var builder = WebApplication.CreateBuilder(args);

builder.AddApplicationServices();

var app = builder.Build();

app.UseExceptionHandler();

app.MapDefaultEndpoints();

var apiVersionSet = app.NewApiVersionSet().HasApiVersion(new(1, 0)).ReportApiVersions().Build();

app.UseDefaultOpenApi();

app.MapEndpoints(apiVersionSet);

app.MapGrpcService<ProductService>();

app.Run();
