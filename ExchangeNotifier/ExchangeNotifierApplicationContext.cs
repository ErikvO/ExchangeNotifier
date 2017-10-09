using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ErikvO.ExchangeNotifier.Business;
using ErikvO.ExchangeNotifier.Forms;

namespace ErikvO.ExchangeNotifier
{
	public class ExchangeNotifierApplicationContext : ApplicationContext
	{
		private Dictionary<String, Int32> _emailAddresses = new Dictionary<String, Int32>();
		private UnreadMailWorker _unreadMailWorker;
		private NotifyIcon _notifyIcon;
		private Mailboxes _mailboxesForm = null;
		private string _balloontipMessage = "Retrieving unread mail count...";

		internal BackgroundWorker _unreadMailWorkerBackgroundWorker = new BackgroundWorker();

		public MonitoredMailboxCollection Mailboxes = new MonitoredMailboxCollection();

		public ExchangeNotifierApplicationContext()
		{
			Application.ApplicationExit += new EventHandler(OnApplicationExit);
			InitializeComponent();
			_notifyIcon.Visible = true;
			Mailboxes = Settings.LoadSettings();
			StartUnreadMailWorker();
		}

		private void InitializeComponent()
		{
			ToolStripMenuItem _closeMenuItem = new ToolStripMenuItem();
			_closeMenuItem.Name = "CloseMenuItem";
			_closeMenuItem.Size = new Size(152, 22);
			_closeMenuItem.Text = "Exit";
			_closeMenuItem.Click += CloseMenuItem_Click;

			ToolStripMenuItem _settingsMenuItem = new ToolStripMenuItem();
			_settingsMenuItem.Name = "SettingsMenuItem";
			_settingsMenuItem.Size = new Size(152, 22);
			_settingsMenuItem.Text = "Settings";
			_settingsMenuItem.Click += SettingsMenuItem_Click;

			ContextMenuStrip _trayIconContextMenu = new ContextMenuStrip();
			_trayIconContextMenu.SuspendLayout();
			_trayIconContextMenu.Items.AddRange(new ToolStripItem[] { _settingsMenuItem, _closeMenuItem });
			_trayIconContextMenu.Name = "notifyIconContextMenu";
			_trayIconContextMenu.Size = new Size(153, 70);
			_trayIconContextMenu.ResumeLayout(false);

			_notifyIcon = new NotifyIcon();
			_notifyIcon.Text = "Exchange notifier";
			_notifyIcon.Icon = Properties.Resources.Oxygen_Icons_org_Oxygen_Places_mail_message;
			_notifyIcon.ContextMenuStrip = _trayIconContextMenu;

			_notifyIcon.MouseClick += _notifyIcon_MouseClick;

			_unreadMailWorker = new UnreadMailWorker(this);
			_unreadMailWorkerBackgroundWorker.WorkerSupportsCancellation = true;
			_unreadMailWorkerBackgroundWorker.WorkerReportsProgress = true;
			_unreadMailWorkerBackgroundWorker.DoWork += UnreadMailWorker_DoWork;
			_unreadMailWorkerBackgroundWorker.ProgressChanged += UnreadMailWorker_ProgressChanged;
		}

		internal void UnreadMailWorker_DoWork(object sender, DoWorkEventArgs e)
		{
			_unreadMailWorker.Start();
		}

		internal void StartUnreadMailWorker()
		{
			if (!_unreadMailWorkerBackgroundWorker.IsBusy)
				_unreadMailWorkerBackgroundWorker.RunWorkerAsync();
		}

		internal void StopUnreadMailWorker()
		{
			_unreadMailWorkerBackgroundWorker.CancelAsync();
		}

		internal void UnreadMailWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			_balloontipMessage = (string)e.UserState;
			ShowBalloonTip();
		}

		private void ShowBalloonTip()
		{
			if (!String.IsNullOrEmpty(_balloontipMessage))
				_notifyIcon.ShowBalloonTip(3000, "Unread mails", _balloontipMessage, ToolTipIcon.Info);
		}

		private void _notifyIcon_MouseClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
				ShowBalloonTip();
		}

		private void SettingsMenuItem_Click(object sender, EventArgs e)
		{
			if (_mailboxesForm != null && _mailboxesForm.Visible)
			{
				_mailboxesForm.Activate();
				return;
			}

			_mailboxesForm = new Mailboxes(Mailboxes);
			_mailboxesForm.FormClosed += SettingsForm_FormClosed;
			_mailboxesForm.ShowDialog();
		}

		private void SettingsForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			_mailboxesForm.Dispose();
			_mailboxesForm = null;
		}

		private void CloseMenuItem_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show(
				"Close Exchange notifier?",
				"Are you sure?",
				MessageBoxButtons.YesNo,
				MessageBoxIcon.Exclamation,
				MessageBoxDefaultButton.Button2) == DialogResult.Yes)
			{
				Application.Exit();
			}
		}

		private void OnApplicationExit(object sender, EventArgs e)
		{
			//Cleanup so that the icon will be removed when the application is closed
			_notifyIcon.Visible = false;
		}
	}
}