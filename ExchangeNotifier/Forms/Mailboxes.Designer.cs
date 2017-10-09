namespace ErikvO.ExchangeNotifier.Forms
{
	partial class Mailboxes
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.btnAddEmailAddress = new System.Windows.Forms.Button();
			this.btnRemoveEmailAddress = new System.Windows.Forms.Button();
			this.lbMonitoredMailboxes = new System.Windows.Forms.ListBox();
			this.lblMonitoredMailboxes = new System.Windows.Forms.Label();
			this.btnSave = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnAddEmailAddress
			// 
			this.btnAddEmailAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAddEmailAddress.Location = new System.Drawing.Point(12, 341);
			this.btnAddEmailAddress.Name = "btnAddEmailAddress";
			this.btnAddEmailAddress.Size = new System.Drawing.Size(23, 23);
			this.btnAddEmailAddress.TabIndex = 5;
			this.btnAddEmailAddress.Text = "+";
			this.btnAddEmailAddress.UseVisualStyleBackColor = true;
			this.btnAddEmailAddress.Click += new System.EventHandler(this.btnAddEmailAddress_Click);
			// 
			// btnRemoveEmailAddress
			// 
			this.btnRemoveEmailAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnRemoveEmailAddress.Location = new System.Drawing.Point(41, 341);
			this.btnRemoveEmailAddress.Name = "btnRemoveEmailAddress";
			this.btnRemoveEmailAddress.Size = new System.Drawing.Size(23, 23);
			this.btnRemoveEmailAddress.TabIndex = 6;
			this.btnRemoveEmailAddress.Text = "-";
			this.btnRemoveEmailAddress.UseVisualStyleBackColor = true;
			this.btnRemoveEmailAddress.Click += new System.EventHandler(this.btnRemoveEmailAddress_Click);
			// 
			// lbMonitoredMailboxes
			// 
			this.lbMonitoredMailboxes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lbMonitoredMailboxes.FormattingEnabled = true;
			this.lbMonitoredMailboxes.Location = new System.Drawing.Point(12, 36);
			this.lbMonitoredMailboxes.Name = "lbMonitoredMailboxes";
			this.lbMonitoredMailboxes.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
			this.lbMonitoredMailboxes.Size = new System.Drawing.Size(584, 303);
			this.lbMonitoredMailboxes.TabIndex = 0;
			this.lbMonitoredMailboxes.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbMonitoredMailboxes_MouseDoubleClick);
			// 
			// lblMonitoredMailboxes
			// 
			this.lblMonitoredMailboxes.AutoSize = true;
			this.lblMonitoredMailboxes.Location = new System.Drawing.Point(12, 9);
			this.lblMonitoredMailboxes.Name = "lblMonitoredMailboxes";
			this.lblMonitoredMailboxes.Size = new System.Drawing.Size(104, 13);
			this.lblMonitoredMailboxes.TabIndex = 7;
			this.lblMonitoredMailboxes.Text = "Monitored Mailboxes";
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(440, 345);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(75, 23);
			this.btnSave.TabIndex = 8;
			this.btnSave.Text = "Save";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(521, 345);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 8;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// Mailboxes
			// 
			this.AcceptButton = this.btnSave;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(611, 376);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.lblMonitoredMailboxes);
			this.Controls.Add(this.lbMonitoredMailboxes);
			this.Controls.Add(this.btnRemoveEmailAddress);
			this.Controls.Add(this.btnAddEmailAddress);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.Name = "Mailboxes";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Settings";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Button btnAddEmailAddress;
		private System.Windows.Forms.Button btnRemoveEmailAddress;
		private System.Windows.Forms.Label lblMonitoredMailboxes;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.ListBox lbMonitoredMailboxes;
		private System.Windows.Forms.Button btnCancel;
	}
}