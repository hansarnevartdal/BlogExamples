using System.Runtime.Serialization;
using Airline.Services.Reward.Contracts.Enums;

namespace Airline.Services.Reward.Contracts.Messages
{
    [DataContract]
    public class GetRewardProgramResponse
    {
        [DataMember]
        public RewardLevel RewardLevel { get; set; }
    }
}