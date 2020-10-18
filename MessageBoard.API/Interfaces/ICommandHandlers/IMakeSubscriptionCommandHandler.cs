using MessagingBoard.RequestModels.CommandRequestModels;
using MessagingBoard.ResponseModels.CommandResponseModels;

namespace MessagingBoard.Interfaces.ICommandHandlers
{
	public interface IMakeSubscriptionCommandHandler
	{
		MakeSubscriptionResponseModel MakeSubscription(MakeSubscriptionRequestModel requestModel);
	}
}