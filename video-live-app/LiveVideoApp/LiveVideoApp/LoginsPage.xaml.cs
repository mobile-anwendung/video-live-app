using System;
using System.Collections.Generic;
using Newtonsoft.Json;


using Xamarin.Forms;

namespace LiveVideoApp
{
    
    
    public partial class LoginsPage : ContentPage
    {
        Request request;
        public LoginsPage()
        {
            request = new Request("http://home.htw-berlin.de/~s0554918/LiveVideoApp/loggin/", "POST");
            InitializeComponent();
            Entry_Benutzername.Text = "pauldaobou@yahoo.fr";
            Entry_Password.Text = "125A";
        }
        public LoginsPage(string Username = null, string password = null)
        {
            InitializeComponent();
            Entry_Benutzername.Text = Username;
        }

        async void Button_Registrieren_Login_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegistrierungsPage());
        }

        async void Passwort_Ruecksetzen_Tapped(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new PassRuecksetzen());
        }

		async void Button_Loggin_Login_Clicked(object sender, System.EventArgs e)
		{
            User user = new User();

            user.Email = Entry_Benutzername.Text;
            user.Passwort = Entry_Password.Text;

            string json = request.CreateJsonObject(RequestTyp.Loggin, user);

            await DisplayAlert("Op", json, "kd");
            object repo = request.Execute(json);

            Responce responce = (Responce)repo;
            await DisplayAlert("yo", responce.Result.ToString(), "Ok");
            Result result = (Result)request.GetResponceObject(responce);

            if (responce.Executed)
            {
                if (result.LoggedIn)
                {
					user = result.User;

					await Navigation.PushAsync(new HomePage(user));
                }
                else
                {
                    await DisplayAlert("Error", "Email oder Passwort falsch", "Ok");
                    Entry_Password.Text = "";
                    Entry_Benutzername.Focus();
                }
            }
            else
            {
                await DisplayAlert("Error", "Keine Verbindung mit dem Server", "Ok");
            }
        }
    }
}
