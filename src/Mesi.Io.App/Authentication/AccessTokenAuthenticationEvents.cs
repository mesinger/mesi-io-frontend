using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Logging;

namespace Mesi.Io.App.Authentication
{
    public class AccessTokenAuthenticationEvents : CookieAuthenticationEvents
    {
        private readonly ILogger<AccessTokenAuthenticationEvents> _logger;

        public AccessTokenAuthenticationEvents(ILogger<AccessTokenAuthenticationEvents> logger)
        {
            _logger = logger;
        }

        /// <inheritdoc />
        public override async Task ValidatePrincipal(CookieValidatePrincipalContext context)
        {
            var hasValidExpirationDate = DateTimeOffset.TryParse(context.Properties.GetTokenValue("expires_at"), out var expiresAt);

            if (!hasValidExpirationDate || expiresAt.UtcDateTime < DateTime.UtcNow - TimeSpan.FromSeconds(30))
            {
                context.RejectPrincipal();
                await context.HttpContext.SignOutAsync("Cookies");
            }
        }
    }
}