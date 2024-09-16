using MediatR;
using MessagingBoard.ResponseModels.QueryResponseModels;

namespace MessagingBoard.RequestModels.QueryRequestModels
{
	public class GetPostsByProjectRequestModel : IRequest<GetPostsByProjectResponseModel>
	{
		public string Project { get; set; }
	}
}