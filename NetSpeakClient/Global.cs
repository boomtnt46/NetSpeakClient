namespace NetSpeakClient
{
    static class Global
    {
        public static string username { get; set; }

        public class Net
        {
            public static System.Net.Sockets.Socket server { get; set; }
        }
        public class Messages
        {
            public class Login
            {
                public string username { get; set; }
                public string password { get; set; }
            }
            public class LoginResponse
            {
                public string status { get; set; }
                public string loginMessage { get; set; }
            }
            public class Message
            {
                public string message { get; set; }
            }
            public class Registration
            {
                public string type = "registration";
                public string username { get; set; }
                public string password { get; set; }
            }
        }
    }


}
