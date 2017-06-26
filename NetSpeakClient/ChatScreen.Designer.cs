namespace NetSpeakClient
{
    partial class ChatScreen
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
            this.sendButton = new System.Windows.Forms.Button();
            this.messages = new System.Windows.Forms.ListBox();
            this.users = new System.Windows.Forms.ListBox();
            this.disconnectButton = new System.Windows.Forms.Button();
            this.messageToSend = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // sendButton
            // 
            this.sendButton.AutoSize = true;
            this.sendButton.Location = new System.Drawing.Point(8, 387);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(427, 30);
            this.sendButton.TabIndex = 0;
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // messages
            // 
            this.messages.FormattingEnabled = true;
            this.messages.ItemHeight = 20;
            this.messages.Location = new System.Drawing.Point(9, 8);
            this.messages.Margin = new System.Windows.Forms.Padding(2);
            this.messages.Name = "messages";
            this.messages.Size = new System.Drawing.Size(428, 344);
            this.messages.TabIndex = 1;
            // 
            // users
            // 
            this.users.FormattingEnabled = true;
            this.users.ItemHeight = 20;
            this.users.Location = new System.Drawing.Point(440, 38);
            this.users.Margin = new System.Windows.Forms.Padding(2);
            this.users.Name = "users";
            this.users.Size = new System.Drawing.Size(181, 364);
            this.users.TabIndex = 2;
            // 
            // disconnectButton
            // 
            this.disconnectButton.Location = new System.Drawing.Point(441, 8);
            this.disconnectButton.Margin = new System.Windows.Forms.Padding(2);
            this.disconnectButton.Name = "disconnectButton";
            this.disconnectButton.Size = new System.Drawing.Size(179, 29);
            this.disconnectButton.TabIndex = 3;
            this.disconnectButton.Text = "Disconnect";
            this.disconnectButton.UseVisualStyleBackColor = true;
            this.disconnectButton.Click += new System.EventHandler(this.disconnectButton_Click);
            // 
            // messageToSend
            // 
            this.messageToSend.Location = new System.Drawing.Point(7, 356);
            this.messageToSend.Margin = new System.Windows.Forms.Padding(2);
            this.messageToSend.MaxLength = 500;
            this.messageToSend.Name = "messageToSend";
            this.messageToSend.Size = new System.Drawing.Size(428, 26);
            this.messageToSend.TabIndex = 4;
            this.messageToSend.TextChanged += new System.EventHandler(this.messageToSend_TextChanged);
            // 
            // ChatScreen
            // 
            this.AcceptButton = this.sendButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.ClientSize = new System.Drawing.Size(632, 410);
            this.Controls.Add(this.messageToSend);
            this.Controls.Add(this.disconnectButton);
            this.Controls.Add(this.users);
            this.Controls.Add(this.messages);
            this.Controls.Add(this.sendButton);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ChatScreen";
            this.Text = "ChatScreen";
            this.Load += new System.EventHandler(this.ChatScreen_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.ListBox messages;
        private System.Windows.Forms.ListBox users;
        private System.Windows.Forms.Button disconnectButton;
        private System.Windows.Forms.TextBox messageToSend;
    }
}