using System;
using System.Collections.Generic;
using SQLite;
using Xamarin.Forms;

namespace GermanApp.Views
{
    public partial class GroupedTranslations : ContentPage
    {
        private SQLiteAsyncConnection _connection;

        async void VerbLoad(object sender, System.EventArgs e)
        {
           // await _connection.CreateTableAsync<translation>();
           // var Translations = await _connection.Table<translation>().Where(i => i.english.Contains(e.NewTextValue)).ToListAsync();

         //   TranslationList.ItemsSource = Translations;
            await Navigation.PushAsync(new Libary("verb"));
          
        }

        async void NumberLoad(object sender, System.EventArgs e)
        {
            
            await Navigation.PushAsync(new Libary("number"));

        }

        async void NounsLoad(object sender, System.EventArgs e)
        {

            await Navigation.PushAsync(new Libary("nouns"));

        }

        async void HelpLoad(object sender, System.EventArgs e)
        {

            await Navigation.PushAsync(new Libary("help"));

        }

        async void ColourLoad(object sender, System.EventArgs e)
        {

            await Navigation.PushAsync(new Libary("colour"));

        }

        async void CalendarLoad(object sender, System.EventArgs e)
        {
            
            await Navigation.PushAsync(new Libary("calendar"));

        }

        async void ConversationLoad(object sender, System.EventArgs e)
        {

            await Navigation.PushAsync(new Libary("conversation"));

        }

        async void DirectionsLoad(object sender, System.EventArgs e)
        {

            await Navigation.PushAsync(new Libary("directions"));

        }


        public GroupedTranslations()
        {
            InitializeComponent();
            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();
          
        }
    }
}
