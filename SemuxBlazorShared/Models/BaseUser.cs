namespace SemuxBlazorShared.Models
{
    public class BaseUser
    {
        public Renci.SshNet.SftpClient SftpClient { get; set; }
        public BaseUser()
        {
            Connect();
        }
        public string Name = string.Empty;
        public string HOST = string.Empty;
        public string Password = string.Empty;

        public void Connect()
        {

            try
            {
                SftpClient = new Renci.SshNet.SftpClient(HOST, Name, Password);

                SftpClient.Connect();


            }
            catch (Exception e)
            {
                SemuxBlazorShared.Models.Console.WriteLine(e.Message);

            }
        }

        public override string ToString()
        {

            return $"UserName: {Name}, Password: {Password}";
        }
    }
}
