namespace Client10
{
    partial class Chat
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Chat));
            this.InputName = new System.Windows.Forms.TextBox();
            this.OutputMessage = new System.Windows.Forms.RichTextBox();
            this.InputMessage = new System.Windows.Forms.RichTextBox();
            this.SendButton = new System.Windows.Forms.Button();
            this.AbonentList = new System.Windows.Forms.CheckedListBox();
            this.ConnDisconnButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.LoginPanel = new System.Windows.Forms.GroupBox();
            this.SendPanel = new System.Windows.Forms.Panel();
            this.AbonentListPanel = new System.Windows.Forms.GroupBox();
            this.ForAllCheck = new System.Windows.Forms.Button();
            this.ShowButton = new System.Windows.Forms.Button();
            this.Customization = new System.Windows.Forms.GroupBox();
            this.ChatThemesList = new System.Windows.Forms.ComboBox();
            this.LoginPanel.SuspendLayout();
            this.SendPanel.SuspendLayout();
            this.AbonentListPanel.SuspendLayout();
            this.Customization.SuspendLayout();
            this.SuspendLayout();
            // 
            // InputName
            // 
            this.InputName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.InputName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.InputName.Location = new System.Drawing.Point(6, 19);
            this.InputName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.InputName.MaxLength = 16;
            this.InputName.Name = "InputName";
            this.InputName.Size = new System.Drawing.Size(160, 21);
            this.InputName.TabIndex = 2;
            this.InputName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.InputName_KeyDown);
            // 
            // OutputMessage
            // 
            this.OutputMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OutputMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.OutputMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.OutputMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.OutputMessage.Location = new System.Drawing.Point(206, 70);
            this.OutputMessage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.OutputMessage.Name = "OutputMessage";
            this.OutputMessage.ReadOnly = true;
            this.OutputMessage.Size = new System.Drawing.Size(570, 283);
            this.OutputMessage.TabIndex = 3;
            this.OutputMessage.Text = "";
            // 
            // InputMessage
            // 
            this.InputMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InputMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.InputMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.InputMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.InputMessage.Location = new System.Drawing.Point(0, 0);
            this.InputMessage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.InputMessage.Name = "InputMessage";
            this.InputMessage.ReadOnly = true;
            this.InputMessage.Size = new System.Drawing.Size(486, 75);
            this.InputMessage.TabIndex = 4;
            this.InputMessage.Text = "";
            this.InputMessage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.InputMessage_KeyDown);
            // 
            // SendButton
            // 
            this.SendButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.SendButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.SendButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SendButton.Enabled = false;
            this.SendButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SendButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.SendButton.Location = new System.Drawing.Point(490, 26);
            this.SendButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(75, 22);
            this.SendButton.TabIndex = 5;
            this.SendButton.Text = "Send";
            this.SendButton.UseVisualStyleBackColor = false;
            this.SendButton.Click += new System.EventHandler(this.SendButton_Click);
            // 
            // AbonentList
            // 
            this.AbonentList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.AbonentList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.AbonentList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AbonentList.CheckOnClick = true;
            this.AbonentList.Enabled = false;
            this.AbonentList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.AbonentList.FormattingEnabled = true;
            this.AbonentList.Location = new System.Drawing.Point(12, 70);
            this.AbonentList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.AbonentList.Name = "AbonentList";
            this.AbonentList.Size = new System.Drawing.Size(186, 354);
            this.AbonentList.TabIndex = 6;
            // 
            // ConnDisconnButton
            // 
            this.ConnDisconnButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.ConnDisconnButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ConnDisconnButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ConnDisconnButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.ConnDisconnButton.Location = new System.Drawing.Point(171, 18);
            this.ConnDisconnButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ConnDisconnButton.Name = "ConnDisconnButton";
            this.ConnDisconnButton.Size = new System.Drawing.Size(75, 22);
            this.ConnDisconnButton.TabIndex = 7;
            this.ConnDisconnButton.Text = "Connect";
            this.ConnDisconnButton.UseVisualStyleBackColor = false;
            this.ConnDisconnButton.Click += new System.EventHandler(this.ConnDisconnButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.ExitButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ExitButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.ExitButton.Location = new System.Drawing.Point(254, 18);
            this.ExitButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(75, 22);
            this.ExitButton.TabIndex = 8;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = false;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // LoginPanel
            // 
            this.LoginPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.LoginPanel.Controls.Add(this.InputName);
            this.LoginPanel.Controls.Add(this.ExitButton);
            this.LoginPanel.Controls.Add(this.ConnDisconnButton);
            this.LoginPanel.ForeColor = System.Drawing.Color.White;
            this.LoginPanel.Location = new System.Drawing.Point(206, 13);
            this.LoginPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.LoginPanel.Name = "LoginPanel";
            this.LoginPanel.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.LoginPanel.Size = new System.Drawing.Size(334, 48);
            this.LoginPanel.TabIndex = 9;
            this.LoginPanel.TabStop = false;
            this.LoginPanel.Text = "Enter your name:";
            // 
            // SendPanel
            // 
            this.SendPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SendPanel.Controls.Add(this.SendButton);
            this.SendPanel.Controls.Add(this.InputMessage);
            this.SendPanel.Location = new System.Drawing.Point(206, 359);
            this.SendPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SendPanel.Name = "SendPanel";
            this.SendPanel.Size = new System.Drawing.Size(568, 73);
            this.SendPanel.TabIndex = 10;
            // 
            // AbonentListPanel
            // 
            this.AbonentListPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.AbonentListPanel.Controls.Add(this.ForAllCheck);
            this.AbonentListPanel.Controls.Add(this.ShowButton);
            this.AbonentListPanel.ForeColor = System.Drawing.Color.White;
            this.AbonentListPanel.Location = new System.Drawing.Point(12, 13);
            this.AbonentListPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.AbonentListPanel.Name = "AbonentListPanel";
            this.AbonentListPanel.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.AbonentListPanel.Size = new System.Drawing.Size(188, 48);
            this.AbonentListPanel.TabIndex = 11;
            this.AbonentListPanel.TabStop = false;
            this.AbonentListPanel.Text = "Abonents";
            // 
            // ForAllCheck
            // 
            this.ForAllCheck.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.ForAllCheck.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ForAllCheck.Enabled = false;
            this.ForAllCheck.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ForAllCheck.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.ForAllCheck.Location = new System.Drawing.Point(98, 19);
            this.ForAllCheck.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ForAllCheck.Name = "ForAllCheck";
            this.ForAllCheck.Size = new System.Drawing.Size(75, 22);
            this.ForAllCheck.TabIndex = 1;
            this.ForAllCheck.Text = "All";
            this.ForAllCheck.UseVisualStyleBackColor = false;
            this.ForAllCheck.Click += new System.EventHandler(this.ForAllCheck_Click);
            // 
            // ShowButton
            // 
            this.ShowButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.ShowButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ShowButton.Enabled = false;
            this.ShowButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ShowButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.ShowButton.Location = new System.Drawing.Point(6, 19);
            this.ShowButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ShowButton.Name = "ShowButton";
            this.ShowButton.Size = new System.Drawing.Size(75, 22);
            this.ShowButton.TabIndex = 0;
            this.ShowButton.Text = "Show";
            this.ShowButton.UseVisualStyleBackColor = false;
            this.ShowButton.Click += new System.EventHandler(this.ShowButton_Click);
            // 
            // Customization
            // 
            this.Customization.Controls.Add(this.ChatThemesList);
            this.Customization.ForeColor = System.Drawing.Color.White;
            this.Customization.Location = new System.Drawing.Point(544, 13);
            this.Customization.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Customization.Name = "Customization";
            this.Customization.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Customization.Size = new System.Drawing.Size(230, 48);
            this.Customization.TabIndex = 12;
            this.Customization.TabStop = false;
            this.Customization.Text = "Chat theme";
            // 
            // ChatThemesList
            // 
            this.ChatThemesList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.ChatThemesList.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ChatThemesList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.ChatThemesList.FormattingEnabled = true;
            this.ChatThemesList.Items.AddRange(new object[] {
            "Dark theme",
            "Light theme"});
            this.ChatThemesList.Location = new System.Drawing.Point(20, 18);
            this.ChatThemesList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ChatThemesList.Name = "ChatThemesList";
            this.ChatThemesList.Size = new System.Drawing.Size(192, 21);
            this.ChatThemesList.TabIndex = 0;
            this.ChatThemesList.Text = "Dark theme";
            this.ChatThemesList.SelectedIndexChanged += new System.EventHandler(this.ChatThemesList_SelectedIndexChanged);
            // 
            // Chat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.ClientSize = new System.Drawing.Size(801, 449);
            this.Controls.Add(this.Customization);
            this.Controls.Add(this.AbonentListPanel);
            this.Controls.Add(this.SendPanel);
            this.Controls.Add(this.LoginPanel);
            this.Controls.Add(this.AbonentList);
            this.Controls.Add(this.OutputMessage);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(817, 488);
            this.Name = "Chat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.LoginPanel.ResumeLayout(false);
            this.LoginPanel.PerformLayout();
            this.SendPanel.ResumeLayout(false);
            this.AbonentListPanel.ResumeLayout(false);
            this.Customization.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox InputName;
        private System.Windows.Forms.RichTextBox OutputMessage;
        private System.Windows.Forms.RichTextBox InputMessage;
        private System.Windows.Forms.Button SendButton;
        private System.Windows.Forms.CheckedListBox AbonentList;
        private System.Windows.Forms.Button ConnDisconnButton;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.GroupBox LoginPanel;
        private System.Windows.Forms.Panel SendPanel;
        private System.Windows.Forms.GroupBox AbonentListPanel;
        private System.Windows.Forms.Button ShowButton;
        private System.Windows.Forms.Button ForAllCheck;
        private System.Windows.Forms.GroupBox Customization;
        private System.Windows.Forms.ComboBox ChatThemesList;
    }
}

