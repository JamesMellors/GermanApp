using System;
using System.Collections.Generic;
using Xamarin.Forms;
using SQLite;
namespace GermanApp.Views
{
    public partial class MyView : ContentView
    {

        private SQLiteAsyncConnection _connection;
        public MyView()
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
