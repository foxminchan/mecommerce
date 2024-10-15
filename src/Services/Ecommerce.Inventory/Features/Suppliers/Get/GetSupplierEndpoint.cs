using Ecommerce.Inventory.Domain.SupplierAggregate;

namespace Ecommerce.Inventory.Features.Suppliers.Get;

internal sealed class GetSupplierEndpoint
    : IEndpoint<Results<Ok<SupplierDto>, NotFound>, GetSupplierQuery, ISender>
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet(
                "/suppliers/{id:long}",
                async (long id, ISender sender) => await HandleAsync(new(id), sender)
            )
            .ProducesOk<SupplierDto>()
            .ProducesNotFound()
            .WithOpenApi()
            .WithTags(nameof(Supplier))
            .MapToApiVersion(new(1, 0));
    }

    public async Task<Results<Ok<SupplierDto>, NotFound>> HandleAsync(
        GetSupplierQuery request,
        ISender sender,
        CancellationToken cancellationToken = default
    )
    {
        var result = await sender.Send(request, cancellationToken);

        return result.Status == ResultStatus.NotFound
            ? TypedResults.NotFound()
            : TypedResults.Ok(result.Value);
    }
}
