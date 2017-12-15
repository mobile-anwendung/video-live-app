using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace livevideo
{
    public partial class LoginsPage : ContentPage
    {
        public LoginsPage(string Username = null, string password = null)
        {
            InitializeComponent();
        }

        async void Button_Registrieren_Login_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegistrierungsPage());
        }
    }
}
