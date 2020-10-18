﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MessagingBoard.ResponseModels.CommandResponseModels;
using Newtonsoft.Json;

namespace MessageBoard.ConsoleUI.Command
{
	public class PostMessageCommand : Command
	{
		private string _userName = string.Empty;
		private string _project = string.Empty;
		private string _message = string.Empty;

		public PostMessageCommand() : base()
		{
			this._regExPattern = @"^ *(\S+) +(@\S+) +(.+)$";
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
						var url = "posts/makepost";
						webClient.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
						webClient.Headers[HttpRequestHeader.ContentType] = "application/json";
						var messageBody = new { UserName = this._userName, Project = this._project, Message = this._message };
						string data = JsonConvert.SerializeObject(messageBody);
						var jsonResponse = webClient.UploadString(url, data);
						var response = JsonConvert.DeserializeObject<MakePostResponseModel>(jsonResponse);
						result.Add(response.IsSuccess ? "Message has been posted successfully!" : "Error posting a new message");
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
				if (matches.Count == 1 && matches[0].Groups.Count == 4)
				{
					_userName = matches[0].Groups[1].Value;
					_project = matches[0].Groups[2].Value.Trim();
					_project = _project.Substring(1, _project.Length - 1);
					_message = matches[0].Groups[3].Value;
					_canExecute = true;
				}
				
			}
			return _canExecute;
		}
	}
}