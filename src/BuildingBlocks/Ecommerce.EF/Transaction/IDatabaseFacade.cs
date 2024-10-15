using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Ecommerce.EF.Transaction;

public interface IDatabaseFacade
{
    DatabaseFacade Database { get; }
}
