using MediatR;
using MessagingBoard.BusinessModels;
using MessagingBoard.Interfaces.IQueryHandlers;
using MessagingBoard.RequestModels.QueryRequestModels;
using MessagingBoard.ResponseModels.QueryResponseModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MessagingBoard.Handlers.QueryHandlers
{
	public class GetPostsByProjectQueryHandler : IRequestHandler<GetPostsByProjectRequestModel, GetPostsByProjectResponseModel>
	{
		private readonly IMessageBoard _messageBoard;

		public GetPostsByProjectQueryHandler(IMessageBoard _messageBoard)
		{
			this._messageBoard = _messageBoard;
		}

		public async Task<GetPostsByProjectResponseModel> Handle(GetPostsByProjectRequestModel request, CancellationToken cancellationToken)
		{
			var posts = _messageBoard.
				Messages().
				Where(m => m.Project.Equals(request.Project, System.StringComparison.OrdinalIgnoreCase))
				.OrderBy(m => m.UserName).ThenBy(m => m.DateCreated).ToList();

			List<string> response = new List<string>();
			if (posts.Count > 0)
			{
				response.Add(request.Project);
				string prevUser = string.Empty;
				string currentUser = string.Empty;
				foreach (Message message in posts)
				{
					currentUser = message.UserName;
					if (currentUser != prevUser)
					{
						response.Add(currentUser);
					}
					response.Add(message.ToString());
					prevUser = currentUser;
				}
			}
			return await Task.Run(() => new GetPostsByProjectResponseModel { Messages = response }); ;
		}
	}
}