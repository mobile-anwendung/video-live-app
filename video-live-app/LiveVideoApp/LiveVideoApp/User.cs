using System;
namespace LiveVideoApp
{
	public class User
	{
        private int id;
		private string benutzername;
		private string email;
		private string passwort;
		bool online;
		bool all;
		bool live;

		int[] friends;
		int[] confirmed;
		int[] refused;
		int[] toConfirm;

		public User()
		{

		}

        public User(string n, bool m)
        {
            this.Benutzername = n;
            this.live = m;
        }

        public int Id { get => id; set => id = value; }
		public string Benutzername { get => benutzername; set => benutzername = value; }
		public string Email { get => email; set => email = value; }
		public string Passwort { get => passwort; set => passwort = value; }
		public int[] ToConfirm { get => toConfirm; set => toConfirm = value; }
		public int[] Refused { get => refused; set => refused = value; }
		public int[] Confirmed { get => confirmed; set => confirmed = value; }
		public int[] Friends { get => friends; set => friends = value; }
		public bool Live { get => live; set => live = value; }
		public bool All { get => all; set => all = value; }
		public bool Online { get => online; set => online = value; }
	}

}
