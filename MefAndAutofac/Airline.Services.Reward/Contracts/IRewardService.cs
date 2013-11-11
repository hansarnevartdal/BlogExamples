using System.ServiceModel;
using Airline.Services.Reward.Contracts.Messages;

namespace Airline.Services.Reward.Contracts
{
    [ServiceContract]
    public interface IRewardService
    {
        [OperationContract]
        GetRewardProgramResponse GetRewardProgram(GetRewardProgramRequest rewardProgramRequest);
    }

    public interface IRewardServiceClient : IRewardService, IClientChannel
    { }
}
