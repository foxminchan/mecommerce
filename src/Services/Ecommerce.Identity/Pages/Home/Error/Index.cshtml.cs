﻿// Copyright (c) Duende Software. All rights reserved.
// See LICENSE in the project root for license information.

namespace Ecommerce.Identity.Pages.Home.Error;

[AllowAnonymous]
[SecurityHeaders]
public sealed class Index(
    IIdentityServerInteractionService interaction,
    IWebHostEnvironment environment
) : PageModel
{
    public ViewModel View { get; set; } = new();

    public async Task OnGet(string? errorId)
    {
        // retrieve error details from identity-server
        var message = await interaction.GetErrorContextAsync(errorId);
        if (message is not null)
        {
            View.Error = message;

            if (!environment.IsDevelopment())
            {
                // only show in development
                message.ErrorDescription = null;
            }
        }
    }
}
