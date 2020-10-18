using MediatR;
using MessagingBoard.Interfaces.ICommandHandlers;
using MessagingBoard.Interfaces.IQueryHandlers;
using MessagingBoard.RequestModels.CommandRequestModels;
using MessagingBoard.RequestModels.QueryRequestModels;
using Microsoft.AspNetCore.Mvc;

namespace MessagingBoard.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class PostsController : ControllerBase
	{
		private readonly IMediator _mediator;

		public PostsController(IMediator mediator)
		{
			this._mediator = mediator;
		}

		[HttpPost("makepost")]
		public IActionResult MakePost([FromBody] MakePostRequestModel requestModel)
		{
			var response = _mediator.Send(requestModel);
			return Ok(response.Result);
		}

		[HttpPost("makesubscription")]
		public IActionResult MakeSubscription([FromBody] MakeSubscriptionRequestModel requestModel)
		{
			var response = _mediator.Send(requestModel);
			return Ok(response.Result);
		}

		[HttpGet("project")]
		public IActionResult GetProjectPosts([FromQuery] GetPostsByProjectRequestModel requestModel)
		{
			var response = _mediator.Send(requestModel);
			return Ok(response.Result);
		}

		[HttpGet("wall")]
		public IActionResult GetSubscriptionsPosts([FromQuery] GetPostsBySubscriptionRequestModel requestModel)
		{
			var response = _mediator.Send(requestModel);
			return Ok(response.Result);
		}
	}
}