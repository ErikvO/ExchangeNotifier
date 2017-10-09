using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;

namespace ErikvO.ExchangeNotifier.Business
{
	[Serializable]
	public class MonitoredMailbox
	{
		private string EncryptedPassword { get; set; }

		public string EmailAddress { get; set; }
		public string Domain { get; set; }
		public string UserName { get; set; }
		public string ServerUrl { get; set; }

		public string DecryptedPassword
		{
			get { return EncryptedPassword == null ? "" : Encryption.Decrypt(EncryptedPassword, "MonitoredMailbox"); }
			set { EncryptedPassword = Encryption.Encrypt(value, "MonitoredMailbox"); }
		}

		private BindingList<string> _additionalMailboxes = null;
		public BindingList<string> AdditionalMailboxes
		{
			get
			{
				if (_additionalMailboxes == null)
					_additionalMailboxes = new BindingList<string>();
				return _additionalMailboxes;
			}
			set
			{
				_additionalMailboxes = value;
			}
		}

		internal NetworkCredential Credential
		{
			get { return new NetworkCredential(UserName, DecryptedPassword, Domain); }
		}

		internal List<string> EmailAddresses
		{
			get
			{
				string domainName = EmailAddress.Substring(EmailAddress.IndexOf('@'));
				return Enumerable
					.Repeat(EmailAddress, 1)
					.Concat(
						AdditionalMailboxes
						.Select(additionMailbox => $"{additionMailbox}{domainName}")
					)
					.ToList();
			}
		}
	}
}