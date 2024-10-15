using Ecommerce.Location.Domain.StateOrProvinceAggregate;
using Ecommerce.Location.Domain.StateOrProvinceAggregate.Specifications;

namespace Ecommerce.Location.Features.StateOrProvinces.Delete;

internal sealed class DeleteStateOrProvinceValidator : AbstractValidator<StateOrProvince>
{
    private readonly IReadRepository<StateOrProvince> _repository;

    public DeleteStateOrProvinceValidator(IReadRepository<StateOrProvince> repository)
    {
        _repository = repository;

        RuleFor(x => x.Id)
            .MustAsync(NotAssignedInDistrict)
            .WithMessage("State or province is assigned in district.");
    }

    private async Task<bool> NotAssignedInDistrict(long id, CancellationToken cancellationToken)
    {
        var stateOrProvince = await _repository.FirstOrDefaultAsync(
            new StateOrProvinceFilterSpec(id),
            cancellationToken
        );

        return stateOrProvince is not null;
    }
}
