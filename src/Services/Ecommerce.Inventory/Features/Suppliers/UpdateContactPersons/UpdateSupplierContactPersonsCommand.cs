using Ecommerce.Inventory.Domain.SupplierAggregate;

namespace Ecommerce.Inventory.Features.Suppliers.UpdateContactPersons;

internal sealed record UpdateSupplierContactPersonsCommand(
    long Id,
    List<ContactPersonRequest> ContactPersons
) : ICommand;

internal sealed class UpdateSupplierContactPersonsHandler(IRepository<Supplier> repository)
    : ICommandHandler<UpdateSupplierContactPersonsCommand>
{
    public async Task<Result> Handle(
        UpdateSupplierContactPersonsCommand request,
        CancellationToken cancellationToken
    )
    {
        var supplier = await repository.GetByIdAsync(request.Id, cancellationToken);

        if (supplier is null)
        {
            return Result.NotFound();
        }

        supplier.UpdateContactPersons(
            request.ContactPersons.Select(x => new ContactPerson(x.Name, x.Email, x.Phone)).ToList()
        );

        await repository.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
