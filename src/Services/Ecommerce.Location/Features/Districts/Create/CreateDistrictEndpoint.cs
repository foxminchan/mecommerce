﻿using Ecommerce.Location.Domain.DistrictAggregate;
using Auth = Ecommerce.Constant.Auth;

namespace Ecommerce.Location.Features.Districts.Create;

internal sealed class CreateDistrictEndpoint
    : IEndpoint<Created<long>, CreateDistrictCommand, ISender>
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost(
                "/districts",
                async (CreateDistrictCommand command, ISender sender) =>
                    await HandleAsync(command, sender)
            )
            .ProducesCreated<long>()
            .ProducesValidationProblem()
            .WithOpenApi()
            .WithTags(nameof(District))
            .MapToApiVersion(new(1, 0))
            .RequireAuthorization(Auth.Policies.Admin);
    }

    public async Task<Created<long>> HandleAsync(
        CreateDistrictCommand request,
        ISender sender,
        CancellationToken cancellationToken = default
    )
    {
        var result = await sender.Send(request, cancellationToken);

        return TypedResults.Created($"/api/v1/districts/{result.Value}", result.Value);
    }
}
