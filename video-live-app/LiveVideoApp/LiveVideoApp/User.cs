using System;
namespace LiveVideoApp
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
