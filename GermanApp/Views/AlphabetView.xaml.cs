using System;
using System.Collections.Generic;
using GermanApp.Persistence;
using GermanApp.Models;
using SQLite;
using Xamarin.Forms;

namespace GermanApp.Views
{
    public partial class AlphabetView : ContentPage
    {
        private SQLiteAsyncConnection _connection;


        public AlphabetView()
        {
            InitializeComponent();
            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();
        }

        protected async override void OnAppearing()
        {
            await _connection.CreateTableAsync<Alphabet>();
            var abc = await _connection.Table<Alphabet>().ToListAsync();
            abcList.ItemsSource = abc;

            base.OnAppearing();
        }

        void Handle_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            var letter = e.SelectedItem as Alphabet;
            var File = letter.german + ".mp3";

            //File = File.Replace(" ", "");

            DependencyService.Get<IAudio>().PlayAudioFile(File);
        }
    }
}
