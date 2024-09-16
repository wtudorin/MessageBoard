using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagingBoard.BusinessModels
{
	public class ProjectSubscriptions : IProjectSubscriptions
	{
		private List<Subscription> _subscriptions = null;

		public List<Subscription> Subscriptions()
		{
			if (_subscriptions == null)
			{
				_subscriptions = new List<Subscription>();
			}
			return _subscriptions;
		}
	}
}