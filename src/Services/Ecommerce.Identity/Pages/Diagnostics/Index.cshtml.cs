﻿// Copyright (c) Duende Software. All rights reserved.
// See LICENSE in the project root for license information.

namespace Ecommerce.Identity.Pages.Diagnostics;

[SecurityHeaders]
[Authorize]
public sealed class Index : PageModel
{
    public ViewModel View { get; set; } = default!;

    public async Task<IActionResult> OnGet()
    {
        var localAddresses = new List<string?> { "127.0.0.1", "::1" };
        if (HttpContext.Connection.LocalIpAddress is not null)
        {
            localAddresses.Add(HttpContext.Connection.LocalIpAddress.ToString());
        }

        if (!localAddresses.Contains(HttpContext.Connection.RemoteIpAddress?.ToString()))
        {
            return NotFound();
        }

        View = new ViewModel(await HttpContext.AuthenticateAsync());

        return Page();
    }
}
