using System;
using System.Collections.Generic;
using Microsoft.Exchange.WebServices.Data;

namespace ErikvO.ExchangeNotifier.Business
{
	public class MailboxInfo
	{
		private ExchangeService _service;

		public MonitoredMailbox Mailbox { get; private set; }
		public Dictionary<string, int> UnreadMailCount { get; private set; }

		public MailboxInfo(MonitoredMailbox mailbox)
		{
			Mailbox = mailbox;

			_service = new ExchangeService(ExchangeVersion.Exchange2010);
			_service.Credentials = mailbox.Credential;
			_service.Url = new Uri(mailbox.ServerUrl);

			UnreadMailCount = new Dictionary<string, int>();

			Mailbox.EmailAddresses.ForEach(emailAddress =>
			{
				int initialUnreadMailCount = GetInitialUnreadMailCountForAddress(emailAddress);
				UnreadMailCount.Add(emailAddress, initialUnreadMailCount);
			});

			//TODO: Subscribe to mailbox changes.
		}

		private Int32 GetInitialUnreadMailCountForAddress(String emailAddress)
		{
			ItemView viewEmails = new ItemView(int.MaxValue) { PropertySet = new PropertySet(BasePropertySet.IdOnly) };
			SearchFilter unreadFilter = new SearchFilter.SearchFilterCollection(LogicalOperator.And, new SearchFilter.IsEqualTo(EmailMessageSchema.IsRead, false));

			FolderId InboxId = new FolderId(WellKnownFolderName.Inbox, emailAddress);
			FindItemsResults<Item> findResults = _service.FindItems(InboxId, unreadFilter, viewEmails);
			Int32 unreadCount = findResults.TotalCount;

			FolderView viewFolders = new FolderView(int.MaxValue) { Traversal = FolderTraversal.Deep, PropertySet = new PropertySet(BasePropertySet.IdOnly) };
			FindFoldersResults inboxFolders = _service.FindFolders(WellKnownFolderName.Inbox, viewFolders);
			foreach (Folder folder in inboxFolders.Folders)
			{
				findResults = _service.FindItems(folder.Id, unreadFilter, viewEmails);
				unreadCount += findResults.TotalCount;
			}

			return unreadCount;
		}
	}
}