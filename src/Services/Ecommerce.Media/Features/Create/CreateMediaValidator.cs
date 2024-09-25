namespace Ecommerce.Media.Features.Create;

internal sealed class CreateMediaValidator : AbstractValidator<CreateMediaCommand>
{
    public CreateMediaValidator()
    {
        RuleFor(x => x.File).NotNull();

        RuleFor(x => x.MediaType).IsInEnum();

        RuleFor(x => x.Caption).NotEmpty().MaximumLength(DataSchemaLength.Max);
    }
}
