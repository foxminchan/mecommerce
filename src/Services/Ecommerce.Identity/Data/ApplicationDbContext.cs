using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Ecommerce.Identity.Data;

public sealed class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : IdentityDbContext<ApplicationUser>(options),
        IDatabaseFacade;
