using System;
using System.Windows.Forms;

namespace ErikvO.ExchangeNotifier.Forms
{
	public partial class AddAdditionalMailbox : Form
	{
		private MailboxSettings _parentForm;
		private int _index;

		public AddAdditionalMailbox(MailboxSettings parentForm, int index = -1, string additionalMailboxName = "")
		{
			_parentForm = parentForm;
			_index = index;
			InitializeComponent();
			tbAdditionalMailboxName.Text = additionalMailboxName;
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			_parentForm.SetAdditionalMailbox(_index, tbAdditionalMailboxName.Text);
			this.Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
