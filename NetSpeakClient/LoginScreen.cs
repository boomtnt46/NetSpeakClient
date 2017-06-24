using System;
using System.Net.Sockets;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace NetSpeakClient
{
    public partial class loginScreen : Form
    {
        public loginScreen()
        {
            InitializeComponent();
            usernameTextBox.Enabled = false;
            passwordTextBox.Enabled = false;
        }

        private void advancedLogin_CheckedChanged(object sender, EventArgs e)
        {
            if (advancedLogin.Checked)
            {
                usernameTextBox.Enabled = true;
                usernameTextBox.Text = "";
                passwordTextBox.Enabled = true;
                passwordTextBox.Text = "";
            }
            else
            {
                usernameTextBox.Enabled = false;
                usernameTextBox.Text = "Anonymous";
                passwordTextBox.Enabled = false;
                passwordTextBox.Text = "Anonymous";
            }
            
        }

        private void connectButton_Click(object sender, EventArgs e)
        {


            if (ipAddressTextBox.Text == "" || portTextBox.Text == "") return;
            //Check to avoid exceptions

            IPAddress ip = IPAddress.Parse(ipAddressTextBox.Text);

            ConnectAndLogin(ip, int.Parse(portTextBox.Text), usernameTextBox.Text, passwordTextBox.Text);
            //This initializes a connection to the server and tries to log in (if required)
        }

        private void ConnectAndLogin(IPAddress ip, int port, string username, string password)
        {
            Global.Net.connection = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            Global.Net.connection.Connect(new IPEndPoint(ip, port));
            //Connect to server

            if (Global.Net.connection.Connected)
            {
                Global.Messages.LoginResponse loginResult = Login(new string[2] { username, password });
                //Try to log in and return the server response

                if (loginResult.status == "OK")
                {
                    MessageBox.Show("Succesfully connected!");
                    this.Hide();
                    ChatScreen chatScreen = new ChatScreen();
                    chatScreen.WriteLoginMessage(loginResult.loginMessage);
                    chatScreen.Show();
                    //Hide this window and then open the chat screen
                }
                //In the following "if sections" no further action will be made, other that warning the user
                else if (loginResult.status == "BAD LOGIN")
                {
                    MessageBox.Show("Server refused to log in because you entered invalid username or password.");
                }
                else if (loginResult.status == "BANNED")
                {
                    MessageBox.Show("You are banned: " + loginResult.loginMessage);
                }
            }
            else
            {

            }

        }


        private Global.Messages.LoginResponse Login(string[] loginInfo)
        {
            
            Global.Messages.Login login = new Global.Messages.Login();
            login.username = loginInfo[0];
            login.password = loginInfo[1];

            string loginPackage = JsonConvert.SerializeObject(login);

            Global.Net.connection.Send(Encoding.UTF8.GetBytes(loginPackage));
            
            byte[] response = new byte[256];
            Global.Net.connection.Receive(response);
            Global.Messages.LoginResponse deserializedResponse = (Global.Messages.LoginResponse) JsonConvert.DeserializeObject(Encoding.UTF8.GetString(response));
            return deserializedResponse;

        }

    }
    
}
