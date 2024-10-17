using Ecommerce.Location.Domain.WardOrCommuneAggregate;
using Ecommerce.Location.Domain.WardOrCommuneAggregate.Specifications;

namespace Ecommerce.Location.Features.WardOrCommunes.Delete;

internal sealed class DeleteWardOrCommuneValidator : AbstractValidator<DeleteWardOrCommuneCommand>
{
    private readonly IReadRepository<WardOrCommune> _repository;

    public DeleteWardOrCommuneValidator(IReadRepository<WardOrCommune> repository)
    {
        _repository = repository;

        RuleFor(x => x.Id)
            .MustAsync(NotAssignedInAddress)
            .WithMessage("Ward or commune is assigned in address.");
    }

    private async Task<bool> NotAssignedInAddress(long id, CancellationToken cancellationToken)
    {
        var wardOrCommune = await _repository.GetByIdAsync(
            new WardOrCommuneFilterSpec(id),
            cancellationToken
        );

        return wardOrCommune is not null;
    }
}
