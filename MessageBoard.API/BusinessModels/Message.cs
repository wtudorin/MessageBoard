using System;

namespace MessagingBoard.BusinessModels
{
	public class Message
	{
		public string UserName { get; set; }
		public string Project { get; set; }
		public string Content { get; set; }
		public DateTime DateCreated { get; set; }

		public override string ToString()
		{
			//return $"{Project} - {UserName}: {Content} {(DateTime.UtcNow.Subtract(DateCreated).TotalMinutes >= 1 ? $"( {(int)DateTime.UtcNow.Subtract(DateCreated).TotalMinutes} minutes ago)" : "")}";
			return $"{Content} {(DateTime.UtcNow.Subtract(DateCreated).TotalMinutes >= 1 ? $"( {(int)DateTime.UtcNow.Subtract(DateCreated).TotalMinutes} minutes ago)" : "")}";
		}
	}
}