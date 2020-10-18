using MessagingBoard.RequestModels.QueryRequestModels;
using MessagingBoard.ResponseModels.QueryResponseModels;

namespace MessagingBoard.Interfaces.IQueryHandlers
{
	public interface IGetPostsByProjectQueryHandler
	{
		GetPostsByProjectResponseModel GetPosts(GetPostsByProjectRequestModel requestModel);
	}
}