using System.Collections.Generic;

namespace MessageBoard.ConsoleUI.Command
{
	public abstract class Command : ICommand
	{
		protected bool _canExecute = false;
		protected string _commandLine = string.Empty;
		protected string _regExPattern;

		public string CommandLine
		{
			get
			{
				return _commandLine;
			}
			set
			{
				this._commandLine = value;
			}
		}

		public abstract List<string> Execute();

		public abstract bool Match();

		public void SetCommandLine(string commandLine)
		{
			this._commandLine = commandLine;
		}
	}
}