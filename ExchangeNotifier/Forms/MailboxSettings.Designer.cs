namespace ErikvO.ExchangeNotifier.Forms
{
	partial class MailboxSettings
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
			this.lblDomain = new System.Windows.Forms.Label();
			this.lblServerUrl = new System.Windows.Forms.Label();
			this.lblUserName = new System.Windows.Forms.Label();
			this.lblPassword = new System.Windows.Forms.Label();
			this.tbDomain = new System.Windows.Forms.TextBox();
			this.tbUserName = new System.Windows.Forms.TextBox();
			this.tbServerUrl = new System.Windows.Forms.TextBox();
			this.tbPassword = new System.Windows.Forms.TextBox();
			this.lblEmailAddress = new System.Windows.Forms.Label();
			this.tbEmailAddress = new System.Windows.Forms.TextBox();
			this.btnAutoDiscover = new System.Windows.Forms.Button();
			this.btnOk = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.lbAdditionalMailboxes = new System.Windows.Forms.ListBox();
			this.lblAdditionalMailboxes = new System.Windows.Forms.Label();
			this.btnAddAdditionalMailboxes = new System.Windows.Forms.Button();
			this.btnRemoveAdditionalMailboxes = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// lblDomain
			// 
			this.lblDomain.AutoSize = true;
			this.lblDomain.Location = new System.Drawing.Point(12, 48);
			this.lblDomain.Name = "lblDomain";
			this.lblDomain.Size = new System.Drawing.Size(43, 13);
			this.lblDomain.TabIndex = 0;
			this.lblDomain.Text = "Domain";
			// 
			// lblServerUrl
			// 
			this.lblServerUrl.AutoSize = true;
			this.lblServerUrl.Location = new System.Drawing.Point(12, 87);
			this.lblServerUrl.Name = "lblServerUrl";
			this.lblServerUrl.Size = new System.Drawing.Size(101, 13);
			this.lblServerUrl.TabIndex = 0;
			this.lblServerUrl.Text = "Exchange server url";
			// 
			// lblUserName
			// 
			this.lblUserName.AutoSize = true;
			this.lblUserName.Location = new System.Drawing.Point(212, 48);
			this.lblUserName.Name = "lblUserName";
			this.lblUserName.Size = new System.Drawing.Size(57, 13);
			this.lblUserName.TabIndex = 0;
			this.lblUserName.Text = "UserName";
			// 
			// lblPassword
			// 
			this.lblPassword.AutoSize = true;
			this.lblPassword.Location = new System.Drawing.Point(412, 48);
			this.lblPassword.Name = "lblPassword";
			this.lblPassword.Size = new System.Drawing.Size(53, 13);
			this.lblPassword.TabIndex = 0;
			this.lblPassword.Text = "Password";
			// 
			// tbDomain
			// 
			this.tbDomain.Location = new System.Drawing.Point(15, 64);
			this.tbDomain.Name = "tbDomain";
			this.tbDomain.Size = new System.Drawing.Size(180, 20);
			this.tbDomain.TabIndex = 2;
			// 
			// tbUserName
			// 
			this.tbUserName.Location = new System.Drawing.Point(215, 64);
			this.tbUserName.Name = "tbUserName";
			this.tbUserName.Size = new System.Drawing.Size(180, 20);
			this.tbUserName.TabIndex = 3;
			// 
			// tbServerUrl
			// 
			this.tbServerUrl.Location = new System.Drawing.Point(15, 103);
			this.tbServerUrl.Name = "tbServerUrl";
			this.tbServerUrl.Size = new System.Drawing.Size(499, 20);
			this.tbServerUrl.TabIndex = 5;
			// 
			// tbPassword
			// 
			this.tbPassword.Location = new System.Drawing.Point(415, 64);
			this.tbPassword.Name = "tbPassword";
			this.tbPassword.PasswordChar = '*';
			this.tbPassword.Size = new System.Drawing.Size(180, 20);
			this.tbPassword.TabIndex = 4;
			// 
			// lblEmailAddress
			// 
			this.lblEmailAddress.AutoSize = true;
			this.lblEmailAddress.Location = new System.Drawing.Point(12, 9);
			this.lblEmailAddress.Name = "lblEmailAddress";
			this.lblEmailAddress.Size = new System.Drawing.Size(73, 13);
			this.lblEmailAddress.TabIndex = 0;
			this.lblEmailAddress.Text = "Email Address";
			// 
			// tbEmailAddress
			// 
			this.tbEmailAddress.Location = new System.Drawing.Point(15, 25);
			this.tbEmailAddress.Name = "tbEmailAddress";
			this.tbEmailAddress.Size = new System.Drawing.Size(580, 20);
			this.tbEmailAddress.TabIndex = 1;
			// 
			// btnAutoDiscover
			// 
			this.btnAutoDiscover.Location = new System.Drawing.Point(520, 102);
			this.btnAutoDiscover.Name = "btnAutoDiscover";
			this.btnAutoDiscover.Size = new System.Drawing.Size(75, 22);
			this.btnAutoDiscover.TabIndex = 6;
			this.btnAutoDiscover.Text = "Lookup";
			this.btnAutoDiscover.UseVisualStyleBackColor = true;
			this.btnAutoDiscover.Click += new System.EventHandler(this.btnAutoDiscover_Click);
			// 
			// btnOk
			// 
			this.btnOk.Location = new System.Drawing.Point(439, 273);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(75, 22);
			this.btnOk.TabIndex = 7;
			this.btnOk.Text = "Ok";
			this.btnOk.UseVisualStyleBackColor = true;
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(520, 273);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 22);
			this.btnCancel.TabIndex = 8;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// lbAdditionalMailboxes
			// 
			this.lbAdditionalMailboxes.FormattingEnabled = true;
			this.lbAdditionalMailboxes.Location = new System.Drawing.Point(15, 146);
			this.lbAdditionalMailboxes.Name = "lbAdditionalMailboxes";
			this.lbAdditionalMailboxes.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
			this.lbAdditionalMailboxes.Size = new System.Drawing.Size(580, 121);
			this.lbAdditionalMailboxes.TabIndex = 9;
			this.lbAdditionalMailboxes.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbAdditionalMailboxes_MouseDoubleClick);
			// 
			// lblAdditionalMailboxes
			// 
			this.lblAdditionalMailboxes.AutoSize = true;
			this.lblAdditionalMailboxes.Location = new System.Drawing.Point(12, 130);
			this.lblAdditionalMailboxes.Name = "lblAdditionalMailboxes";
			this.lblAdditionalMailboxes.Size = new System.Drawing.Size(103, 13);
			this.lblAdditionalMailboxes.TabIndex = 10;
			this.lblAdditionalMailboxes.Text = "Additional Mailboxes";
			// 
			// btnAddAdditionalMailboxes
			// 
			this.btnAddAdditionalMailboxes.Location = new System.Drawing.Point(15, 272);
			this.btnAddAdditionalMailboxes.Name = "btnAddAdditionalMailboxes";
			this.btnAddAdditionalMailboxes.Size = new System.Drawing.Size(23, 23);
			this.btnAddAdditionalMailboxes.TabIndex = 11;
			this.btnAddAdditionalMailboxes.Text = "+";
			this.btnAddAdditionalMailboxes.UseVisualStyleBackColor = true;
			this.btnAddAdditionalMailboxes.Click += new System.EventHandler(this.btnAddAdditionalMailboxes_Click);
			// 
			// btnRemoveAdditionalMailboxes
			// 
			this.btnRemoveAdditionalMailboxes.Location = new System.Drawing.Point(44, 272);
			this.btnRemoveAdditionalMailboxes.Name = "btnRemoveAdditionalMailboxes";
			this.btnRemoveAdditionalMailboxes.Size = new System.Drawing.Size(23, 23);
			this.btnRemoveAdditionalMailboxes.TabIndex = 11;
			this.btnRemoveAdditionalMailboxes.Text = "-";
			this.btnRemoveAdditionalMailboxes.UseVisualStyleBackColor = true;
			this.btnRemoveAdditionalMailboxes.Click += new System.EventHandler(this.btnRemoveAdditionalMailboxes_Click);
			// 
			// MailboxSettings
			// 
			this.AcceptButton = this.btnOk;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(611, 306);
			this.Controls.Add(this.btnRemoveAdditionalMailboxes);
			this.Controls.Add(this.btnAddAdditionalMailboxes);
			this.Controls.Add(this.lblAdditionalMailboxes);
			this.Controls.Add(this.lbAdditionalMailboxes);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.btnAutoDiscover);
			this.Controls.Add(this.lblDomain);
			this.Controls.Add(this.lblEmailAddress);
			this.Controls.Add(this.lblServerUrl);
			this.Controls.Add(this.lblUserName);
			this.Controls.Add(this.tbPassword);
			this.Controls.Add(this.lblPassword);
			this.Controls.Add(this.tbEmailAddress);
			this.Controls.Add(this.tbServerUrl);
			this.Controls.Add(this.tbDomain);
			this.Controls.Add(this.tbUserName);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.Name = "MailboxSettings";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "MailboxSettings";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MailboxSettings_FormClosing);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Label lblPassword;
		private System.Windows.Forms.Label lblUserName;
		private System.Windows.Forms.Label lblServerUrl;
		private System.Windows.Forms.Label lblDomain;
		internal System.Windows.Forms.TextBox tbPassword;
		internal System.Windows.Forms.TextBox tbServerUrl;
		internal System.Windows.Forms.TextBox tbUserName;
		internal System.Windows.Forms.TextBox tbDomain;
		private System.Windows.Forms.Label lblEmailAddress;
		internal System.Windows.Forms.TextBox tbEmailAddress;
		private System.Windows.Forms.Button btnAutoDiscover;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.ListBox lbAdditionalMailboxes;
		private System.Windows.Forms.Label lblAdditionalMailboxes;
		private System.Windows.Forms.Button btnAddAdditionalMailboxes;
		private System.Windows.Forms.Button btnRemoveAdditionalMailboxes;
	}
}