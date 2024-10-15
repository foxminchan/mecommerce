using Ecommerce.Location.Domain.CountryAggregate;
using Ecommerce.Location.Domain.CountryAggregate.Specifications;

namespace Ecommerce.Location.Features.Countries.Delete;

internal sealed class DeleteCountryValidator : AbstractValidator<Country>
{
    private readonly IReadRepository<Country> _repository;

    public DeleteCountryValidator(IReadRepository<Country> repository)
    {
        _repository = repository;

        RuleFor(x => x.Id)
            .MustAsync(NotAssignedInStateOrProvince)
            .WithMessage("Country is assigned in state or province.");
    }

    private async Task<bool> NotAssignedInStateOrProvince(
        long id,
        CancellationToken cancellationToken
    )
    {
        var country = await _repository.FirstOrDefaultAsync(
            new CountryFilterSpec(id),
            cancellationToken
        );

        return country is not null;
    }
}
