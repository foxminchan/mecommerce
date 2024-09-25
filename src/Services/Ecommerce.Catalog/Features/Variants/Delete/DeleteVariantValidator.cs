using Ecommerce.Catalog.Domain.ProductAggregate;
using Ecommerce.Catalog.Domain.ProductAggregate.Specifications;

namespace Ecommerce.Catalog.Features.Variants.Delete;

internal sealed class DeleteVariantValidator : AbstractValidator<DeleteVariantCommand>
{
    private readonly IReadRepository<Product> _repository;

    public DeleteVariantValidator(IReadRepository<Product> repository)
    {
        _repository = repository;

        RuleFor(x => x.Id)
            .MustAsync(DoesNotAssignedAnyProduct)
            .WithMessage("Variant is assigned to a product.");
    }

    private async Task<bool> DoesNotAssignedAnyProduct(long id, CancellationToken cancellationToken)
    {
        var product = await _repository.FirstOrDefaultAsync(
            new ProductFilterSpec(id),
            cancellationToken
        );

        return product is null;
    }
}
