using System;
using MediatR;
using MessagingBoard.ResponseModels.QueryResponseModels;

namespace MessagingBoard.RequestModels.QueryRequestModels
{
	public class GetPostsBySubscriptionRequestModel : IRequest<GetPostsBySubscriptionResponseModel>
	{
		public string Username { get; set; }
	}
}