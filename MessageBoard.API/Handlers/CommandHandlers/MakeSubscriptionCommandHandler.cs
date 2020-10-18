using MediatR;
using MessagingBoard.BusinessModels;
using MessagingBoard.Interfaces.ICommandHandlers;
using MessagingBoard.RequestModels.CommandRequestModels;
using MessagingBoard.ResponseModels.CommandResponseModels;
using System.Threading;
using System.Threading.Tasks;

namespace MessagingBoard.Handlers.CommandHandlers
{
	public class MakeSubscriptionCommandHandler : IRequestHandler<MakeSubscriptionRequestModel, MakeSubscriptionResponseModel>
	{
		private IProjectSubscriptions _projectSubscriptions;

		public MakeSubscriptionCommandHandler(IProjectSubscriptions projectSubscriptions)
		{
			this._projectSubscriptions = projectSubscriptions;
		}

		public async Task<MakeSubscriptionResponseModel> Handle(MakeSubscriptionRequestModel request, CancellationToken cancellationToken)
		{
			var result = new MakeSubscriptionResponseModel
			{
				IsSuccess = true,
			};

			Subscription newSubscription = new Subscription { Project = request.Project, UserName = request.UserName };
			await Task.Run(() => _projectSubscriptions.Subscriptions().Add(newSubscription));
			return result;
		}
	}
}