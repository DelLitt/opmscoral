namespace AppFrame.Security
{
    public class ClientInfo
    {
        private static ClientInfo clientInfo = null;
        public string Username { get; set; }
        public string EmployeeName { get; set; }
        public string Role { get; set; }

        public ClientInfo(string username, string employeeName, string role)
        {
            Username = username;
            EmployeeName = employeeName;
            Role = role;
        }

        public ClientInfo()
        {
        }

        public static ClientInfo Instance
        {
            get
            {
                if(clientInfo== null)
                {
                    clientInfo = new ClientInfo();
                }
                return clientInfo;
            }
        }
    }
}
