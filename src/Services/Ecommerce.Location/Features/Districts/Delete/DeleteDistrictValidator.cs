using Ecommerce.Location.Domain.DistrictAggregate;
using Ecommerce.Location.Domain.DistrictAggregate.Specifications;

namespace Ecommerce.Location.Features.Districts.Delete;

internal sealed class DeleteDistrictValidator : AbstractValidator<DeleteDistrictCommand>
{
    private readonly IReadRepository<District> _repository;

    public DeleteDistrictValidator(IReadRepository<District> repository)
    {
        _repository = repository;

        RuleFor(x => x.Id)
            .MustAsync(NotAssignedInWardOrCommune)
            .WithMessage("District is assigned in ward or commune.");
    }

    private async Task<bool> NotAssignedInWardOrCommune(
        long id,
        CancellationToken cancellationToken
    )
    {
        var district = await _repository.FirstOrDefaultAsync(
            new DistrictFilterSpec(id),
            cancellationToken
        );

        return district is not null;
    }
}
