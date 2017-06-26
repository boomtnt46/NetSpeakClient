using System;
using Newtonsoft.Json;
using System.Text;
using System.Windows.Forms;

namespace NetSpeakClient
{
    public partial class ChatScreen : Form
    {
        public ChatScreen()
        {
            InitializeComponent();
        }

        private void ChatScreen_Load(object sender, EventArgs e)
        {

        }

        public void WriteLoginMessage(string loginMessage) { messages.Items.Add(loginMessage); }

        private void sendButton_Click(object sender, EventArgs e)
        {
            byte[] messagePackage = new byte[4096];
            messagePackage = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(new Global.Messages.Message { message = messageToSend.Text }));
            Global.Net.server.Send(messagePackage);
            messages.Items.Add(Global.username + " : " + messageToSend.Text);
            messageToSend.Text = String.Empty;
        }

        private void disconnectButton_Click(object sender, EventArgs e)
        {
            Global.Net.server.Disconnect(true);
            this.Close();
            new loginScreen().Show();
        }

        private void messageToSend_TextChanged(object sender, EventArgs e)
        {
            if (Encoding.UTF8.GetByteCount(messageToSend.Text) > 4096)
            {
                char[] text = messageToSend.Text.ToCharArray();
                Array.Resize<char>(ref text, 4096);
                messageToSend.Text = text.ToString();
            }
        }
    }
}
