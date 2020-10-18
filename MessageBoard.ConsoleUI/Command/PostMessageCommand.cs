using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MessageBoard.ConsoleUI.Command
{
	public class PostMessageCommand : Command
	{
		public PostMessageCommand() : base()
		{
			this._regExPattern = @"^ *\S+ +@\S+ +\S+ *$";
		}

		public override List<string> Execute()
		{
			List<string> result = new List<string>();
			if (_canExecute)
			{
			}
			return result;
		}

		public override bool Match()
		{
			if (_commandLine != string.Empty)
			{
				MatchCollection matches = new Regex(_regExPattern).Matches(_commandLine);
				_canExecute = matches.Count > 0;
			}
			return _canExecute;
		}
	}
}