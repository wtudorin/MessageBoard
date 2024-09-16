using System;
using System.Collections.Generic;
using System.Net;
using System.Text.RegularExpressions;
using MessagingBoard.ResponseModels.QueryResponseModels;
using Newtonsoft.Json;

namespace MessageBoard.ConsoleUI.Command
{
	public class WallCommand : Command
	{
		private string _userName = string.Empty;

		public WallCommand() : base()
		{
			this._regExPattern = @"^ *(\S+) +wall *$";
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
						var url = $"posts/wall?username={this._userName}";
						webClient.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
						webClient.Headers[HttpRequestHeader.ContentType] = "application/json";
						var jsonResponse = webClient.DownloadString(url);
						var response = JsonConvert.DeserializeObject<GetPostsBySubscriptionResponseModel>(jsonResponse);
						if (response.Messages.Count > 0)
						{
							result.AddRange(response.Messages);
						}
						else
						{
							result.Add($"No subscriptions found for user {this._userName}");
						}
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
				if (matches.Count == 1 && matches[0].Groups.Count == 2)
				{
					_userName = matches[0].Groups[1].Value.Trim();
					_canExecute = true;
				}
			}
			return _canExecute;
		}
	}
}