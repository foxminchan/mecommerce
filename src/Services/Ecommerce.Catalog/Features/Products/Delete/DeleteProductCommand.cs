using Ecommerce.Catalog.Domain.ProductAggregate;
using Ecommerce.Catalog.Domain.ProductAggregate.Specifications;

namespace Ecommerce.Catalog.Features.Products.Delete;

internal sealed record DeleteProductCommand(Guid Id) : ICommand;

internal sealed class DeleteProductHandler(IRepository<Product> repository)
    : ICommandHandler<DeleteProductCommand>
{
    public async Task<Result> Handle(
        DeleteProductCommand request,
        CancellationToken cancellationToken
    )
    {
        var product = await repository.FirstOrDefaultAsync(
            new ProductFilterSpec(request.Id),
            cancellationToken
        );

        Guard.Against.NotFound(request.Id, product);

        product.Delete();

        await repository.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
