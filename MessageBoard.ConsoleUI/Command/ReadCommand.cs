using System;
using System.Collections.Generic;
using System.Net;
using System.Text.RegularExpressions;
using MessagingBoard.ResponseModels.QueryResponseModels;
using Newtonsoft.Json;

namespace MessageBoard.ConsoleUI.Command
{
	public class ReadCommand : Command
	{
		private string _userName = string.Empty;
		private string _project = string.Empty;

		public ReadCommand() : base()
		{
			this._regExPattern = @"^ *(\S+) *$";
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
						var url = $"posts/project?project={this._project}";
						webClient.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
						webClient.Headers[HttpRequestHeader.ContentType] = "application/json";
						var jsonResponse = webClient.DownloadString(url);
						var response = JsonConvert.DeserializeObject<GetPostsByProjectResponseModel>(jsonResponse);
						if (response.Messages.Count > 0)
						{
							result.AddRange(response.Messages);
						}
						else
						{
							result.Add($"No details found for project {this._project}");
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
					_project = matches[0].Groups[1].Value.Trim();
					_canExecute = true;
				}
			}
			return _canExecute;
		}
	}
}