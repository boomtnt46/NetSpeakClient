using System;
using System.Net.Sockets;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace NetSpeakClient
{
    public partial class loginScreen : Form
    {
        public loginScreen()
        {
            InitializeComponent();
            usernameTextBox.Enabled = false;
            passwordTextBox.Enabled = false;
            usernameTextBox.Text = "Anonymous";
            passwordTextBox.Text = "Anonymous";

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
            if (advancedLogin.Checked && usernameTextBox.Text == "" || passwordTextBox.Text == "")
            {
                MessageBox.Show("Please enter the username or password");
                return;
            }

            if (ipAddressTextBox.Text == "" || portTextBox.Text == "") return;
            //Check to avoid exceptions

            IPAddress ip = IPAddress.Parse(ipAddressTextBox.Text);

            ConnectAndLogin(ip, int.Parse(portTextBox.Text), usernameTextBox.Text, passwordTextBox.Text);
            //This initializes a connection to the server and tries to log in (if required)
        }

        private void ConnectAndLogin(IPAddress ip, int port, string username, string password)
        {
            try
            {
                Global.Net.server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                Global.Net.server.Connect(new IPEndPoint(ip, port));
                //Connect to server

                if (Global.Net.server.Connected)
                {
                    Global.Messages.LoginResponse loginResult = Login(new string[2] { username, password });
                    //Try to log in and return the server response

                    if (loginResult.status == "OK")
                    {
                        MessageBox.Show("Succesfully connected!");
                        Global.username = usernameTextBox.Text;
                        this.Hide();
                        ChatScreen chatScreen = new ChatScreen();
                        chatScreen.WriteLoginMessage(loginResult.loginMessage);
                        chatScreen.Show();
                        //Hide this window and then open the chat screen
                    }
                    //In the following "if sections" no further action will be made, other that warning the user
                    else if (loginResult.status == "USER NOT FOUND")
                    {
                        MessageBox.Show(loginResult.loginMessage);
                    }
                    else if (loginResult.status == "BANNED")
                    {
                        MessageBox.Show("You are banned: " + loginResult.loginMessage);
                    }
                }
                else
                {
                    MessageBox.Show("Couldn't connect to server", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception e) { MessageBox.Show(e.Message); }

        }


        private Global.Messages.LoginResponse Login(string[] loginInfo)
        {

            Global.Messages.Login login = new Global.Messages.Login();
            login.username = loginInfo[0];
            login.password = loginInfo[1];


            string loginPackage = JsonConvert.SerializeObject(login);
            //Convert the object to a string

            Global.Net.server.Send(Encoding.UTF8.GetBytes(loginPackage));
            //The string to bytes and send it

            byte[] response = new byte[256];
            Global.Net.server.Receive(response);
            Global.Messages.LoginResponse deserializedResponse = JsonConvert.DeserializeObject<Global.Messages.LoginResponse>(Encoding.UTF8.GetString(response));
            return deserializedResponse;

        }

        private void loginScreen_Load(object sender, EventArgs e)
        {

        }

        private void connectAndRegister_Click(object sender, EventArgs e)
        {
            if (advancedLogin.Checked && (usernameTextBox.Text == "" || passwordTextBox.Text == ""))
            {
                MessageBox.Show("Please enter the username or password");
                return;
            }

            if (ipAddressTextBox.Text == "" || portTextBox.Text == "") return;
            //Check to avoid exceptions

            IPAddress ip = IPAddress.Parse(ipAddressTextBox.Text);

            ConnectAndRegister(ip, int.Parse(portTextBox.Text), usernameTextBox.Text, passwordTextBox.Text);
        }

        private void ConnectAndRegister(IPAddress ip, int port, string username, string password)
        {
            Global.Net.server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            Global.Net.server.Connect(new IPEndPoint(ip, port));
            //Connect to server

            if (Global.Net.server.Connected)
            {
                Global.Messages.Registration registrationPackage = new Global.Messages.Registration();
                registrationPackage.username = username;
                registrationPackage.password = password;

                Global.Messages.LoginResponse registrationResult = Register(registrationPackage);
                if (registrationResult.status == "OK")
                {
                    MessageBox.Show("Succesfully registered and connected!");
                    Global.username = usernameTextBox.Text;
                    this.Hide();
                    ChatScreen chatScreen = new ChatScreen();
                    chatScreen.WriteLoginMessage(registrationResult.loginMessage);
                    chatScreen.Show();
                    //Hide this window and then open the chat screen
                }
                else if (registrationResult.status == "USER ALREDY EXISTS")
                {
                    MessageBox.Show("Error : The specified user alredy exists");
                }
            }
        }

        private Global.Messages.LoginResponse Register(Global.Messages.Registration reg)
        {
            string registerPackage = JsonConvert.SerializeObject(reg);
            //Convert the object to a JSON string

            Global.Net.server.Send(Encoding.UTF8.GetBytes(registerPackage));
            //The string to bytes and send it

            byte[] response = new byte[256];
            Global.Net.server.Receive(response);
            Global.Messages.LoginResponse deserializedResponse = JsonConvert.DeserializeObject<Global.Messages.LoginResponse>(Encoding.UTF8.GetString(response));
            return deserializedResponse;

        }

    }
}