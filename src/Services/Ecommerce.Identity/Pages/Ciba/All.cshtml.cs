// Copyright (c) Duende Software. All rights reserved.
// See LICENSE in the project root for license information.

namespace Ecommerce.Identity.Pages.Ciba;

[SecurityHeaders]
[Authorize]
public sealed class AllModel(
    IBackchannelAuthenticationInteractionService backchannelAuthenticationInteractionService
) : PageModel
{
    public IEnumerable<BackchannelUserLoginRequest> Logins { get; set; } = default!;

    public async Task OnGet()
    {
        Logins =
            await backchannelAuthenticationInteractionService.GetPendingLoginRequestsForCurrentUserAsync();
    }
}
