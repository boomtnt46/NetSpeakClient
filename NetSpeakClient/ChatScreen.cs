using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
