namespace Client_v1
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.InputName = new System.Windows.Forms.TextBox();
            this.ConnectButton = new System.Windows.Forms.Button();
            this.InputMessage = new System.Windows.Forms.RichTextBox();
            this.SendButton = new System.Windows.Forms.Button();
            this.OutputMessage = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ExitButton = new System.Windows.Forms.Button();
            this.AllABonents = new System.Windows.Forms.CheckedListBox();
            this.MessagePanel = new System.Windows.Forms.Panel();
            this.MessagePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // InputName
            // 
            this.InputName.Location = new System.Drawing.Point(258, 31);
            this.InputName.Name = "InputName";
            this.InputName.Size = new System.Drawing.Size(156, 20);
            this.InputName.TabIndex = 0;
            this.InputName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.InputName_KeyDown);
            // 
            // ConnectButton
            // 
            this.ConnectButton.Location = new System.Drawing.Point(420, 31);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(75, 23);
            this.ConnectButton.TabIndex = 1;
            this.ConnectButton.Text = "Connect";
            this.ConnectButton.UseVisualStyleBackColor = true;
            this.ConnectButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // InputMessage
            // 
            this.InputMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InputMessage.Enabled = false;
            this.InputMessage.Location = new System.Drawing.Point(0, 0);
            this.InputMessage.Name = "InputMessage";
            this.InputMessage.Size = new System.Drawing.Size(449, 67);
            this.InputMessage.TabIndex = 3;
            this.InputMessage.Text = "";
            this.InputMessage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.InputMessage_KeyDown);
            // 
            // SendButton
            // 
            this.SendButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.SendButton.Enabled = false;
            this.SendButton.Location = new System.Drawing.Point(452, 24);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(75, 23);
            this.SendButton.TabIndex = 4;
            this.SendButton.Text = "Send";
            this.SendButton.UseVisualStyleBackColor = true;
            this.SendButton.Click += new System.EventHandler(this.SendButton_Click);
            // 
            // OutputMessage
            // 
            this.OutputMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OutputMessage.BackColor = System.Drawing.SystemColors.Window;
            this.OutputMessage.Enabled = false;
            this.OutputMessage.Location = new System.Drawing.Point(258, 60);
            this.OutputMessage.Name = "OutputMessage";
            this.OutputMessage.ReadOnly = true;
            this.OutputMessage.Size = new System.Drawing.Size(530, 305);
            this.OutputMessage.TabIndex = 5;
            this.OutputMessage.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(258, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Enter your name:";
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(501, 31);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(75, 23);
            this.ExitButton.TabIndex = 2;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // AllABonents
            // 
            this.AllABonents.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.AllABonents.Enabled = false;
            this.AllABonents.FormattingEnabled = true;
            this.AllABonents.Items.AddRange(new object[] {
            "AllAbonents"});
            this.AllABonents.Location = new System.Drawing.Point(12, 12);
            this.AllABonents.Name = "AllABonents";
            this.AllABonents.Size = new System.Drawing.Size(240, 424);
            this.AllABonents.TabIndex = 6;
            // 
            // MessagePanel
            // 
            this.MessagePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MessagePanel.Controls.Add(this.SendButton);
            this.MessagePanel.Controls.Add(this.InputMessage);
            this.MessagePanel.Location = new System.Drawing.Point(258, 371);
            this.MessagePanel.Name = "MessagePanel";
            this.MessagePanel.Size = new System.Drawing.Size(530, 67);
            this.MessagePanel.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AllABonents);
            this.Controls.Add(this.OutputMessage);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.ConnectButton);
            this.Controls.Add(this.InputName);
            this.Controls.Add(this.MessagePanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(816, 489);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.MessagePanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox InputName;
        private System.Windows.Forms.Button ConnectButton;
        private System.Windows.Forms.RichTextBox InputMessage;
        private System.Windows.Forms.Button SendButton;
        private System.Windows.Forms.RichTextBox OutputMessage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.CheckedListBox AllABonents;
        private System.Windows.Forms.Panel MessagePanel;
    }
}

