using System.Collections.Generic;

namespace MessageBoard.ConsoleUI.Command
{
	public class CommandParser
	{
		private List<ICommand> _commands = new List<ICommand>();

		public void AddCommand(ICommand command)
		{
			_commands.Add(command);
		}

		public void ClearCommands()
		{
			_commands.Clear();
		}

		public ICommand Parse(string commandLine)
		{
			foreach (ICommand command in _commands)
			{
				command.SetCommandLine(commandLine);

				if (command.Match())
				{
					return command;
				}
			}
			return null;
		}
	}
}