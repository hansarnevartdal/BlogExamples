using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Security.Claims;
using Airline.Services.Reward.Contracts;
using Airline.Services.Reward.Contracts.Messages;
using Thinktecture.IdentityServer.Repositories;
using Thinktecture.IdentityServer.TokenService;

namespace Airline.IdentityServer.Repositories
{
    class ClaimsRepository : IClaimsRepository
    {
        [Import]
        public IRewardServiceClient RewardService { get; set; }

        public ClaimsRepository()
        {
            Container.Current.SatisfyImportsOnce(this);
        }

        public ClaimsRepository(IRewardServiceClient rewardService)
        {
            RewardService = rewardService;
        }

        public IEnumerable<Claim> GetClaims(ClaimsPrincipal principal, RequestDetails requestDetails)
        {
            var claims = new List<Claim>();
            var nameClaim = principal.Identities.First().FindFirst(ClaimTypes.Name);
            claims.Add(nameClaim);
            var response = RewardService.GetRewardProgram(new GetRewardProgramRequest {UserName = nameClaim.Value});
            if(response != null)
            {
                claims.Add(new Claim("http://oceanicairlines.com/rewardlevel/", response.RewardLevel.ToString()));
            };

            return claims;
        }

        public IEnumerable<string> GetSupportedClaimTypes()
        {
            throw new NotImplementedException();
        }
    }
}
