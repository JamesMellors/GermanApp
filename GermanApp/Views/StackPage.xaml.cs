using System;
using System.Collections.Generic;
using SQLite;
using Xamarin.Forms;

namespace GermanApp
{
    public partial class StackPage : ContentPage
    {
        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new Libary());
        }

        async void GoToGrid(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new GermanApp.Views.GroupedTranslations());
        }

        async void AbcPage(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new Views.AlphabetView());
        }

        public StackPage()
        {
            InitializeComponent();
        }
    }
}
