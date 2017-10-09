using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using ErikvO.ExchangeNotifier.Business;
using Microsoft.Exchange.WebServices.Data;

namespace ErikvO.ExchangeNotifier.Forms
{
	public partial class MailboxSettings : Form
	{
		private Mailboxes _parentForm = null;
		private MonitoredMailbox _mailbox = null;
		private Form _additionalMailboxForm = null;

		public MailboxSettings(Mailboxes parentForm, MonitoredMailbox mailbox)
		{
			_parentForm = parentForm;
			_mailbox = mailbox;
			InitializeComponent();

			tbEmailAddress.Text = _mailbox.EmailAddress;
			tbDomain.Text = _mailbox.Domain;
			tbUserName.Text = _mailbox.UserName;
			tbPassword.Text = _mailbox.DecryptedPassword;
			tbServerUrl.Text = _mailbox.ServerUrl;
			lbAdditionalMailboxes.DataSource = _mailbox.AdditionalMailboxes;
		}

		private void btnAutoDiscover_Click(object sender, EventArgs e)
		{
			ExchangeService service = new ExchangeService(ExchangeVersion.Exchange2010);
			NetworkCredential networkCredential = new NetworkCredential(tbUserName.Text, tbPassword.Text, tbDomain.Text);
			service.Credentials = networkCredential;
			service.AutodiscoverUrl(tbEmailAddress.Text);
			tbServerUrl.Text = service.Url.AbsoluteUri;
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			_mailbox.EmailAddress = tbEmailAddress.Text;
			_mailbox.Domain = tbDomain.Text;
			_mailbox.UserName = tbUserName.Text;
			_mailbox.DecryptedPassword = tbPassword.Text;
			_mailbox.ServerUrl = tbServerUrl.Text;
			_parentForm.AddNewMailbox(_mailbox);
			this.Close();
		}

		private void MailboxSettings_FormClosing(object sender, FormClosingEventArgs e)
		{
			_parentForm = null;
			_mailbox = null;
		}


		private void AdditionalMailboxForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			_additionalMailboxForm.Dispose();
			_additionalMailboxForm = null;
		}

		private void btnAddAdditionalMailboxes_Click(object sender, EventArgs e)
		{
			_additionalMailboxForm = new AddAdditionalMailbox(this);
			_additionalMailboxForm.FormClosed += AdditionalMailboxForm_FormClosed;
			_additionalMailboxForm.ShowDialog();
		}

		private void btnRemoveAdditionalMailboxes_Click(object sender, EventArgs e)
		{
			List<int> selectedIndices = lbAdditionalMailboxes
				.SelectedIndices
				.Cast<int>()
				.OrderByDescending(selectedIndex => selectedIndex)
				.ToList();

			selectedIndices.ForEach(selectedIndex => _mailbox.AdditionalMailboxes.RemoveAt(selectedIndex));
		}

		internal void SetAdditionalMailbox(int index, string additionalMailboxName)
		{
			if (index == -1)
				_mailbox.AdditionalMailboxes.Add(additionalMailboxName);
			else
				_mailbox.AdditionalMailboxes[index] = additionalMailboxName;
		}

		private void lbAdditionalMailboxes_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			int index = lbAdditionalMailboxes.IndexFromPoint(e.Location);
			if (index != ListBox.NoMatches)
			{
				string additionalMailboxName = ((BindingList<string>)lbAdditionalMailboxes.DataSource)[index];
				_additionalMailboxForm = new AddAdditionalMailbox(this, index, additionalMailboxName);
				_additionalMailboxForm.FormClosed += AdditionalMailboxForm_FormClosed;
				_additionalMailboxForm.ShowDialog();
			}
		}
	}
}