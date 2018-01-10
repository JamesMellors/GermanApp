using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace GermanApp
{
    public partial class GreetPage : ContentPage
    {
        
        public GreetPage()
        {
            InitializeComponent();
        }

        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new StackPage());
        }

    }
}
