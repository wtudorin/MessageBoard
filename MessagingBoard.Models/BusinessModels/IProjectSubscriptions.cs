using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagingBoard.BusinessModels
{
	public interface IProjectSubscriptions
	{
		List<Subscription> Subscriptions();
	}
}