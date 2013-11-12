using Thinktecture.IdentityModel.Constants;
using Thinktecture.IdentityServer.Models.Configuration;

namespace Airline.IdentityServer.Repositories.Configuration
{
    class Configuration : GlobalConfiguration
    {
        public Configuration()
        {
            this.IssuerUri = "https://sts.oceanicairlines.com/";
            this.DefaultWSTokenType = TokenTypes.JsonWebToken;
            this.DefaultHttpTokenType = TokenTypes.JsonWebToken;

            DefaultTokenLifetime = 1;
            MaximumTokenLifetime = 8;
        }
    }
}
