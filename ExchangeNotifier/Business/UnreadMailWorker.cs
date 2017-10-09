using System.Collections.Generic;
using System.Linq;

namespace ErikvO.ExchangeNotifier.Business
{
	internal class UnreadMailWorker
	{
		private ExchangeNotifierApplicationContext _parent;
		private MailboxInfoCollection _mailboxInfoCollection = new MailboxInfoCollection();

		internal UnreadMailWorker(ExchangeNotifierApplicationContext parent)
		{
			_parent = parent;
		}

		internal void Start()
		{
			_parent.Mailboxes.ForEach(mailbox => _mailboxInfoCollection.Add(new MailboxInfo(mailbox)));
			ReportMailCount();
		}

		private void ReportMailCount()
		{
			IEnumerable<string> balloontipMessages =
				_mailboxInfoCollection.SelectMany(mailboxInfo =>
					mailboxInfo.UnreadMailCount.Select(unreadMailCount => $"{unreadMailCount.Key}: {unreadMailCount.Value}")
				);

			_parent._unreadMailWorkerBackgroundWorker.ReportProgress(0, string.Join("\r\n", balloontipMessages));
		}
	}
}