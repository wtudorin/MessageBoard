using System.Collections.Generic;

namespace MessagingBoard.BusinessModels
{
	public interface IMessageBoard
	{
		List<Message> Messages();
	}
}