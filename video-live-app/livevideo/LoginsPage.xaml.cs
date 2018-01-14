using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace livevideo
{
    public partial class LoginsPage : ContentPage
    {
        public LoginsPage()
        {
            InitializeComponent();
        }
        public LoginsPage(string Username = null, string password = null)
        {
            InitializeComponent();
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
            await Navigation.PushAsync(new HomePage());
		}
    }
}
