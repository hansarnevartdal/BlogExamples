using Thinktecture.IdentityServer.Models.Configuration;

namespace Airline.IdentityServer.Repositories.Configuration
{
    class WSTrust : WSTrustConfiguration
    {
        public WSTrust()
        {
            Enabled = false;
        }
    }
}
