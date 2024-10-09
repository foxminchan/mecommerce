﻿// Copyright (c) Duende Software. All rights reserved.
// See LICENSE in the project root for license information.

namespace Ecommerce.Identity.Pages.Redirect;

[AllowAnonymous]
public sealed class IndexModel : PageModel
{
    public string? RedirectUri { get; set; }

    public IActionResult OnGet(string? redirectUri)
    {
        if (!Url.IsLocalUrl(redirectUri))
        {
            return RedirectToPage("/Home/Error/Index");
        }

        RedirectUri = redirectUri;
        return Page();
    }
}
