using Ecommerce.Inventory.Domain.SupplierAggregate;
using Auth = Ecommerce.Constant.Auth;

namespace Ecommerce.Inventory.Features.Suppliers.Create;

internal sealed class CreateSupplierEndpoint
    : IEndpoint<Created<long>, CreateSupplierCommand, ISender>
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost(
                "/suppliers",
                async (CreateSupplierCommand request, ISender sender) =>
                    await HandleAsync(request, sender)
            )
            .ProducesCreated<long>()
            .ProducesValidationProblem()
            .WithOpenApi()
            .WithTags(nameof(Supplier))
            .MapToApiVersion(new(1, 0))
            .RequireAuthorization(Auth.Policies.Admin);
    }

    public async Task<Created<long>> HandleAsync(
        CreateSupplierCommand request,
        ISender sender,
        CancellationToken cancellationToken = default
    )
    {
        var result = await sender.Send(request, cancellationToken);

        return TypedResults.Created($"/api/v1/{result.Value}", result.Value);
    }
}
