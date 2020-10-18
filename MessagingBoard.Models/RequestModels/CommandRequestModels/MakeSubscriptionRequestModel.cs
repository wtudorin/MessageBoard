using MediatR;
using MessagingBoard.ResponseModels.CommandResponseModels;

namespace MessagingBoard.RequestModels.CommandRequestModels
{
	public class MakeSubscriptionRequestModel : IRequest<MakeSubscriptionResponseModel>
	{
		public string UserName { get; set; }
		public string Project { get; set; }
	}
}