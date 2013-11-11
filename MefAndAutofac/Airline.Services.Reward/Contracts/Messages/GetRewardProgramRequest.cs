using System.Runtime.Serialization;

namespace Airline.Services.Reward.Contracts.Messages
{
    [DataContract]
    public class GetRewardProgramRequest
    {
        [DataMember]
        public string UserName { get; set; }
    }
}