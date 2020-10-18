using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageBoard.ConsoleUI.Command
{
	public interface ICommand
	{
		bool Match();

		List<string> Execute();
	}
}