using System.Collections.Generic;

namespace MessagingBoard.BusinessModels
{
	public class MessageBoard : IMessageBoard
	{
		private List<Message> _messages = null;

		public List<Message> Messages()
		{
			if (_messages == null)
			{
				_messages = new List<Message>();
			}
			return _messages;
		}
	}
}