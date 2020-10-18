using MessageBoard.ConsoleUI.Command;
using System;
using System.Collections.Generic;

namespace MessageBoard.ConsoleUI
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			CommandParser commandParser = new CommandParser();
			while (true)
			{
				Console.Write("Command > ");
				var commandLine = Console.ReadLine();
				if (commandLine.ToLower().Trim().Equals("exit"))
				{
					return;
				}
				commandParser.ClearCommands();
				commandParser.AddCommand(new PostMessageCommand());
				commandParser.AddCommand(new SubscribeCommand());
				commandParser.AddCommand(new ReadCommand());
				commandParser.AddCommand(new WallCommand());
				var command = commandParser.Parse(commandLine);

				List<string> resultList = null;

				if (command != null)
				{
					ConsoleLogger.Log($"Detected command: {command.GetType().Name}");
					resultList = command.Execute();
					ConsoleLogger.Log(resultList);
				}
				else
				{
					ConsoleLogger.Log("No command was detected!");
				}

			}
		}
	}
}