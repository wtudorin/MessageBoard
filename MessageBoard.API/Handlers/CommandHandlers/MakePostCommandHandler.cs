using MediatR;
using MessagingBoard.BusinessModels;
using MessagingBoard.Interfaces.ICommandHandlers;
using MessagingBoard.RequestModels.CommandRequestModels;
using MessagingBoard.ResponseModels.CommandResponseModels;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MessagingBoard.Handlers.CommandHandlers
{
	public class MakePostCommandHandler : IRequestHandler<MakePostRequestModel, MakePostResponseModel>
	{
		private IMessageBoard _messageBoard;

		public MakePostCommandHandler(IMessageBoard messageBoard)
		{
			this._messageBoard = messageBoard;
		}

		public async Task<MakePostResponseModel> Handle(MakePostRequestModel request, CancellationToken cancellationToken)
		{
			Message newMessage = new Message
			{
				Content = request.Message,
				UserName = request.UserName,
				DateCreated = DateTime.UtcNow,
				Project = request.Project
			};
			this._messageBoard.Messages().Add(newMessage);

			var result = await Task.Run(() => new MakePostResponseModel
			{
				IsSuccess = true,
			});
			return result;
		}
	}
}