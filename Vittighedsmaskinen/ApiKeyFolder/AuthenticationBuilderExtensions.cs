﻿using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vittighedsmaskinen.ApiKeyFolder
{
    public static class AuthenticationBuilderExtensions
    {
        public static AuthenticationBuilder AddApiKeySupport(this AuthenticationBuilder authenticationBuilder, Action<ApiKeyAuthenticationOptions> options)
        {
            return authenticationBuilder.AddScheme<ApiKeyAuthenticationOptions, ApiKeyAuthenticationHandler>(ApiKeyAuthenticationOptions.DefaultScheme, options);
        }
    }
}