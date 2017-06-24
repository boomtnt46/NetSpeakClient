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
            this.sendButton.Location = new System.Drawing.Point(14, 553);
            this.sendButton.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(664, 30);
            this.sendButton.TabIndex = 0;
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = true;
            // 
            // messages
            // 
            this.messages.FormattingEnabled = true;
            this.messages.ItemHeight = 29;
            this.messages.Location = new System.Drawing.Point(14, 12);
            this.messages.Name = "messages";
            this.messages.Size = new System.Drawing.Size(664, 497);
            this.messages.TabIndex = 1;
            // 
            // users
            // 
            this.users.FormattingEnabled = true;
            this.users.ItemHeight = 29;
            this.users.Location = new System.Drawing.Point(693, 12);
            this.users.Name = "users";
            this.users.Size = new System.Drawing.Size(278, 497);
            this.users.TabIndex = 2;
            // 
            // disconnectButton
            // 
            this.disconnectButton.Location = new System.Drawing.Point(693, 553);
            this.disconnectButton.Name = "disconnectButton";
            this.disconnectButton.Size = new System.Drawing.Size(278, 30);
            this.disconnectButton.TabIndex = 3;
            this.disconnectButton.Text = "Disconnect";
            this.disconnectButton.UseVisualStyleBackColor = true;
            // 
            // messageToSend
            // 
            this.messageToSend.Location = new System.Drawing.Point(14, 511);
            this.messageToSend.MaxLength = 500;
            this.messageToSend.Name = "messageToSend";
            this.messageToSend.Size = new System.Drawing.Size(664, 35);
            this.messageToSend.TabIndex = 4;
            // 
            // ChatScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(983, 595);
            this.Controls.Add(this.messageToSend);
            this.Controls.Add(this.disconnectButton);
            this.Controls.Add(this.users);
            this.Controls.Add(this.messages);
            this.Controls.Add(this.sendButton);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
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