using System;
namespace livevideo
{
    public class User
    {
		public string Username;
		public bool Status;

        public User(string username, bool status)
        {
			this.Username = username;
			this.Status = status;
        }
    }
}
