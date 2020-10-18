using MediatR;
using MessagingBoard.BusinessModels;
using MessagingBoard.Interfaces.IQueryHandlers;
using MessagingBoard.RequestModels.QueryRequestModels;
using MessagingBoard.ResponseModels.QueryResponseModels;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MessagingBoard.Handlers.QueryHandlers
{
	public class GetPostsByProjectQueryHandler : IRequestHandler<GetPostsByProjectRequestModel, GetPostsByProjectResponseModel>
	{
		private readonly IMessageBoard _messageBoard;
		private readonly ILogger<GetPostsByProjectQueryHandler> _logger;

		public GetPostsByProjectQueryHandler(IMessageBoard _messageBoard, ILogger<GetPostsByProjectQueryHandler> logger)
		{
			this._messageBoard = _messageBoard;
			this._logger = logger;
		}

		public async Task<GetPostsByProjectResponseModel> Handle(GetPostsByProjectRequestModel request, CancellationToken cancellationToken)
		{
			var posts = _messageBoard.
				Messages().
				Where(m => m.Project.Equals(request.Project, System.StringComparison.OrdinalIgnoreCase))
				.OrderBy(m => m.UserName).ThenBy(m => m.DateCreated).ToList();

			List<string> response = new List<string>();
			this._logger.LogDebug(0, "Retrieving {Posts} posts for project: {Project}", posts.Count, request.Project);

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