using System;
using System.Collections.Generic;
using SQLite;

using Xamarin.Forms;

namespace GermanApp
{

    public class translation
    {
        public int id { get; set; }
        public string english { get; set; }
        public string german { get; set; }
        public string description { get; set; }
        public int key { get; set; } 
        
    }
    public partial class MyPage : ContentPage
    {

        private SQLiteAsyncConnection _connection;
        public MyPage()
        {
            InitializeComponent();
            var connection = DependencyService.Get<ISQLiteDb>().GetConnection();
         
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
