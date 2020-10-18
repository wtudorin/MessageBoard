using System;
using System.Collections.Generic;
using System.Net;
using System.Text.RegularExpressions;
using MessagingBoard.ResponseModels.CommandResponseModels;
using Newtonsoft.Json;

namespace MessageBoard.ConsoleUI.Command
{
	public class SubscribeCommand : Command
	{
		private string _userName = string.Empty;
		private string _project = string.Empty;

		public SubscribeCommand() : base()
		{
			this._regExPattern = @"^ *(\S+) +follows +(\S+) *$";
		}

		public override List<string> Execute()
		{
			List<string> result = new List<string>();
			if (_canExecute)
			{
				try
				{
					using (WebClient webClient = new WebClient())
					{
						webClient.BaseAddress = "https://localhost:5001/";
						var url = "posts/makesubscription";
						webClient.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
						webClient.Headers[HttpRequestHeader.ContentType] = "application/json";
						var messageBody = new { UserName = this._userName, Project = this._project };
						string data = JsonConvert.SerializeObject(messageBody);
						var jsonResponse = webClient.UploadString(url, data);
						var response = JsonConvert.DeserializeObject<MakeSubscriptionResponseModel>(jsonResponse);
						result.Add(response.IsSuccess ? "Subscription was successful!" : $"Error subscribing to project {this._project}");
						return result;
					}
				}
				catch (Exception ex)
				{
					throw ex;
				}
			}
			return result;
		}

		public override bool Match()
		{
			if (_commandLine != string.Empty)
			{
				MatchCollection matches = new Regex(_regExPattern, RegexOptions.IgnoreCase).Matches(_commandLine);
				if (matches.Count == 1 && matches[0].Groups.Count == 3)
				{
					_userName = matches[0].Groups[1].Value;
					_project = matches[0].Groups[2].Value.Trim();
					_canExecute = true;
				}
			}
			return _canExecute;
		}
	}
}