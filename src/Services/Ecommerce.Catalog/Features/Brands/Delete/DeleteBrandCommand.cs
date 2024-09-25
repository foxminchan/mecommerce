using Ecommerce.Catalog.Domain.BrandAggregate;
using Ecommerce.Catalog.Domain.BrandAggregate.Specifications;

namespace Ecommerce.Catalog.Features.Brands.Delete;

internal sealed record DeleteBrandCommand(long Id) : ICommand;

internal sealed class DeleteBrandHandler(IRepository<Brand> repository)
    : ICommandHandler<DeleteBrandCommand>
{
    public async Task<Result> Handle(
        DeleteBrandCommand request,
        CancellationToken cancellationToken
    )
    {
        var brand = await repository.FirstOrDefaultAsync(
            new BrandFilterSpec(request.Id),
            cancellationToken
        );

        if (brand is null)
        {
            return Result.NotFound();
        }

        brand.Delete();

        await repository.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
