using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ErikvO.ExchangeNotifier.Business;

namespace ErikvO.ExchangeNotifier.Forms
{
	public partial class Mailboxes : Form
	{
		private MonitoredMailboxCollection _mailboxes = null;
		private MailboxSettings _mailboxSettingsForm = null;

		public Mailboxes(MonitoredMailboxCollection mailboxes)
		{
			_mailboxes = mailboxes;
			InitializeComponent();

			lbMonitoredMailboxes.DataSource = _mailboxes;
			lbMonitoredMailboxes.DisplayMember = "EmailAddress";
			lbMonitoredMailboxes.ValueMember = "EmailAddress";
		}

		private void MailboxSettingsForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			_mailboxSettingsForm.Dispose();
			_mailboxSettingsForm = null;
		}

		private void btnAddEmailAddress_Click(object sender, System.EventArgs e)
		{
			_mailboxSettingsForm = new MailboxSettings(this, new MonitoredMailbox());
			_mailboxSettingsForm.FormClosed += MailboxSettingsForm_FormClosed;
			_mailboxSettingsForm.ShowDialog();
		}

		private void btnRemoveEmailAddress_Click(object sender, System.EventArgs e)
		{
			List<int> selectedIndices = lbMonitoredMailboxes
				.SelectedIndices
				.Cast<int>()
				.OrderByDescending(selectedIndex => selectedIndex)
				.ToList();

			selectedIndices.ForEach(selectedIndex => _mailboxes.RemoveAt(selectedIndex));
		}

		internal void AddNewMailbox(MonitoredMailbox _mailbox)
		{
			if (!_mailboxes.Contains(_mailbox))
			{
				_mailboxes.Add(_mailbox);
			}
		}

		private void lbMonitoredMailboxes_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			int index = lbMonitoredMailboxes.IndexFromPoint(e.Location);
			if (index != ListBox.NoMatches)
			{
				MonitoredMailbox mailbox = ((MonitoredMailboxCollection)lbMonitoredMailboxes.DataSource)[index];
				_mailboxSettingsForm = new MailboxSettings(this, mailbox);
				_mailboxSettingsForm.FormClosed += MailboxSettingsForm_FormClosed;
				_mailboxSettingsForm.ShowDialog();
			}
		}

		private void btnSave_Click(object sender, System.EventArgs e)
		{
			Business.Settings.SaveSettings(_mailboxes);
			this.Close();
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
	}
}