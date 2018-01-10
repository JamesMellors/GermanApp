using System;
using System.Collections.Generic;
using SQLite;

using Xamarin.Forms;

namespace GermanApp
{

   
    public partial class LibaryView : ContentPage
    {

        private SQLiteAsyncConnection _connection;
        public LibaryView()
        {
            InitializeComponent();
            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();
         
        }

        protected override async void OnAppearing()
        {
            await _connection.CreateTableAsync<translation>();
            var Translations = await _connection.Table<translation>().ToListAsync();
            TranslationList.ItemsSource = Translations;
            base.OnAppearing();
        }
    }
}
