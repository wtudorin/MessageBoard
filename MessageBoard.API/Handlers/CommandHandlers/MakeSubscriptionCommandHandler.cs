using MediatR;
using MessagingBoard.BusinessModels;
using MessagingBoard.Interfaces.ICommandHandlers;
using MessagingBoard.RequestModels.CommandRequestModels;
using MessagingBoard.ResponseModels.CommandResponseModels;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace MessagingBoard.Handlers.CommandHandlers
{
	public class MakeSubscriptionCommandHandler : IRequestHandler<MakeSubscriptionRequestModel, MakeSubscriptionResponseModel>
	{
		private IProjectSubscriptions _projectSubscriptions;
		private readonly ILogger<MakeSubscriptionCommandHandler> _logger;

		public MakeSubscriptionCommandHandler(IProjectSubscriptions projectSubscriptions, ILogger<MakeSubscriptionCommandHandler> logger)
		{
			this._projectSubscriptions = projectSubscriptions;
			this._logger = logger;
		}

		public async Task<MakeSubscriptionResponseModel> Handle(MakeSubscriptionRequestModel request, CancellationToken cancellationToken)
		{
			var result = new MakeSubscriptionResponseModel
			{
				IsSuccess = true,
			};

			Subscription newSubscription = new Subscription { Project = request.Project, UserName = request.UserName };
			await Task.Run(() => _projectSubscriptions.Subscriptions().Add(newSubscription));
			this._logger.LogDebug(0, "Added subscription for user: {UserName} on project: {Project}", newSubscription.UserName, newSubscription.Project);

			return result;
		}
	}
}