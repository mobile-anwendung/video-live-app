using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace LiveVideoApp
{
    public partial class RegistrierungsPage : ContentPage
    {
		Request request;

		public RegistrierungsPage()
        {
			request = new Request("http://home.htw-berlin.de/~s0554918/LiveVideoApp/users/", "POST");

			InitializeComponent();
        }

		async void Button_Registrieen_Clicked(object sender, EventArgs e)
		{
            User user = new User();
            user.Email = Entry_Email.Text;
            user.Benutzername = Entry_Benutzername.Text;

            if (string.Equals(Entry_Password.Text, Entry_Password_Wiederholen.Text))
            {
                user.Passwort = Entry_Password.Text;
            }
            else
            {
                //DisplayAlert();
                return;
            }

            string json = request.CreateJsonObject(RequestTyp.Registrierung, user);
            await DisplayAlert("Json", json, "Ok");
			object repo = request.Execute(json);

			Responce responce = (Responce)repo;
            string result = request.GetResponceObject(responce).ToString();

			if (responce.Executed)
			{
                await DisplayAlert("Info", result, "Ok");
                if (result == "Benutzer regristriert")
                {
                    await Navigation.PushAsync(new LoginsPage(user.Email));
                }
            }
			else
			{
				await DisplayAlert("Error", "Keine Verbindung mit dem Server", "Ok");
			}
        }
    }
}
