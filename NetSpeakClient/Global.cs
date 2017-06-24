namespace NetSpeakClient
{
    static class Global
    {
        public const byte messageByte = 0;
        public const byte loginByte = 2;

        public class Net
        {
            public static System.Net.Sockets.Socket connection { get; set; }
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
        }
    }


}
