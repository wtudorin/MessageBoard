using MediatR;
using MessagingBoard.ResponseModels.CommandResponseModels;

namespace MessagingBoard.RequestModels.CommandRequestModels
{
	public class MakePostRequestModel : IRequest<MakePostResponseModel>
	{
		public string UserName { get; set; }
		public string Project { get; set; }
		public string Message { get; set; }
	}
}