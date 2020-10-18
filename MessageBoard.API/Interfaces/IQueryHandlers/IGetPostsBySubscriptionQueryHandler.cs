using MessagingBoard.RequestModels.QueryRequestModels;
using MessagingBoard.ResponseModels.QueryResponseModels;

namespace MessagingBoard.Interfaces.IQueryHandlers
{
	public interface IGetPostsBySubscriptionQueryHandler
	{
		GetPostsBySubscriptionResponseModel GetPosts(GetPostsBySubscriptionRequestModel requestModel);
	}
}