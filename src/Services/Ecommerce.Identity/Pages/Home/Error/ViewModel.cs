﻿// Copyright (c) Duende Software. All rights reserved.
// See LICENSE in the project root for license information.

namespace Ecommerce.Identity.Pages.Home.Error;

public sealed class ViewModel
{
    public ViewModel() { }

    public ViewModel(string error)
    {
        Error = new() { Error = error };
    }

    public ErrorMessage? Error { get; set; }
}
