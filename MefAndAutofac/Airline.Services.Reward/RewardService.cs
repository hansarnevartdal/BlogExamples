using Airline.Services.Reward.Contracts;
using Airline.Services.Reward.Contracts.Enums;
using Airline.Services.Reward.Contracts.Messages;

namespace Airline.Services.Reward
{
    public class RewardService : IRewardService
    {
        public GetRewardProgramResponse GetRewardProgram(GetRewardProgramRequest rewardProgramRequest)
        {
            // Dummy data for demo purposes
            switch (rewardProgramRequest.UserName)
            {
                case "james.ford":
                    return new GetRewardProgramResponse { RewardLevel = RewardLevel.Bronze };
                    break;
                case "hugo.reyes":
                    return new GetRewardProgramResponse { RewardLevel = RewardLevel.Platinum };
                    break;
                default:
                    return new GetRewardProgramResponse { RewardLevel = RewardLevel.Blue };
            }
        }
    }
}