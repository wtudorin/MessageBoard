using MediatR;
using MessagingBoard.BusinessModels;
using MessagingBoard.Interfaces.ICommandHandlers;
using MessagingBoard.RequestModels.CommandRequestModels;
using MessagingBoard.ResponseModels.CommandResponseModels;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MessagingBoard.Handlers.CommandHandlers
{
	public class MakePostCommandHandler : IRequestHandler<MakePostRequestModel, MakePostResponseModel>
	{
		private IMessageBoard _messageBoard;
		private readonly ILogger _logger;

		public MakePostCommandHandler(IMessageBoard messageBoard, ILogger<MakePostCommandHandler> logger)
		{
			this._messageBoard = messageBoard;
			this._logger = logger;
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
			this._logger.LogDebug(0, "Added message {Message} for user: {UserName} on project: {Project}", newMessage.Content, newMessage.UserName, newMessage.Project);
			var result = await Task.Run(() => new MakePostResponseModel
			{
				IsSuccess = true,
			});
			return result;
		}
	}
}