using MediatR;
using MessagingBoard.BusinessModels;
using MessagingBoard.RequestModels.QueryRequestModels;
using MessagingBoard.ResponseModels.QueryResponseModels;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MessagingBoard.Handlers.QueryHandlers
{
	public class GetPostsBySubscriptionQueryHandler : IRequestHandler<GetPostsBySubscriptionRequestModel, GetPostsBySubscriptionResponseModel>
	{
		private readonly IMessageBoard _messageBoard;
		private readonly IProjectSubscriptions _projectSubscriptions;
		private readonly ILogger<GetPostsBySubscriptionQueryHandler> _logger;

		public GetPostsBySubscriptionQueryHandler(IMessageBoard _messageBoard, IProjectSubscriptions projectSubscriptions, ILogger<GetPostsBySubscriptionQueryHandler> logger)
		{
			this._messageBoard = _messageBoard;
			this._projectSubscriptions = projectSubscriptions;
			this._logger = logger;
		}

		public async Task<GetPostsBySubscriptionResponseModel> Handle(GetPostsBySubscriptionRequestModel request, CancellationToken cancellationToken)
		{
			var projects = _projectSubscriptions.Subscriptions().
			Where(s => s.UserName.Equals(request.Username, System.StringComparison.OrdinalIgnoreCase))
			.OrderBy(s => s.Project).Select(s => s.Project).ToList();

			var posts = _messageBoard.
				Messages().
				Where(m => projects.Any( s => s.Trim().Equals(m.Project.Trim(), System.StringComparison.OrdinalIgnoreCase))).OrderBy(m => m.DateCreated).ToList();

			List<string> response = new List<string>();
			this._logger.LogDebug(0, "Retrieving {Posts} posts for subscriptions of user: {Username}", posts.Count, request.Username);

			if (posts.Count > 0)
			{
				foreach (Message message in posts)
				{
					response.Add($"{message.Project} - {message.UserName}: {message}");
				}
			}
			return await Task.Run(() => new GetPostsBySubscriptionResponseModel { Messages = response });
		}
	}
}