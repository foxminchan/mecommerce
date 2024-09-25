using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Ecommerce.SharedKernel.Endpoints;

public static class ProducesProblemExtensions
{
    public static RouteHandlerBuilder ProducesNotFound(this RouteHandlerBuilder builder)
    {
        return builder.Produces(StatusCodes.Status404NotFound);
    }

    public static RouteHandlerBuilder ProducesCreated<TId>(this RouteHandlerBuilder builder)
    {
        return builder.Produces<TId>(StatusCodes.Status201Created);
    }

    public static RouteHandlerBuilder ProducesNoContent(this RouteHandlerBuilder builder)
    {
        return builder.Produces(StatusCodes.Status204NoContent);
    }

    public static RouteHandlerBuilder ProducesOk<T>(this RouteHandlerBuilder builder)
    {
        return builder.Produces<T>();
    }

    public static RouteHandlerBuilder ProducesOk(this RouteHandlerBuilder builder)
    {
        return builder.Produces(StatusCodes.Status200OK);
    }

    public static RouteHandlerBuilder ProducesConflictProblem(this RouteHandlerBuilder builder)
    {
        return builder.ProducesValidationProblem(StatusCodes.Status409Conflict);
    }

    public static RouteHandlerBuilder ProducesStream(this RouteHandlerBuilder builder)
    {
        builder.Produces<FileStreamHttpResult>(StatusCodes.Status206PartialContent);
        builder.Produces<FileStreamHttpResult>(StatusCodes.Status416RangeNotSatisfiable);
        return builder;
    }
}
