using System;
using System.Collections.Generic;

namespace MessagingBoard.ResponseModels.QueryResponseModels
{
	public class GetPostsBySubscriptionResponseModel
	{
		public List<string> Messages { get; set; }
	}
}