using MessagingBoard.RequestModels.CommandRequestModels;
using MessagingBoard.ResponseModels.CommandResponseModels;

namespace MessagingBoard.Interfaces.ICommandHandlers
{
	public interface IMakePostCommandHandler
	{
		MakePostResponseModel MakePost(MakePostRequestModel requestModel);
	}
}