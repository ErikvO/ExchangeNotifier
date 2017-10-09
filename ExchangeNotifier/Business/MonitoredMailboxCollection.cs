using System;
using System.ComponentModel;

namespace ErikvO.ExchangeNotifier.Business
{
	[Serializable]
	public class MonitoredMailboxCollection : BindingList<MonitoredMailbox>
	{
	}
}