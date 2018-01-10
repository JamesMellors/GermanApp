using System;
using System.Collections.Generic;
using SQLite;
using Xamarin.Forms;

namespace GermanApp
{
    [Table ("translation")]
    public class translation
    {
        
        [Column("id")]
        public int id { get; set; }
        [Column("english")]
        public string english { get; set; }
        [Column("german")]
        public string german { get; set; }
        [Column("description")]
        public string description { get; set; }
        [Column("flagged")]
        public bool flagged { get; set; }

    }
   

   
    public partial class Libary : ContentPage
    {
        private string selectedGroup;


        async void Handle_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            var Word = e.SelectedItem as translation;
            await Navigation.PushAsync(new GermanApp.Views.TranslationDetails(Word));
           // TranslationList.SelectedItem = null;
        }

        async void Handle_TextChanged(object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            await _connection.CreateTableAsync<translation>();

            if (selectedGroup == null)
            {
                var Translations = await _connection.Table<translation>().Where(i => i.english.ToLower().Contains(e.NewTextValue.ToLower())).ToListAsync();
                TranslationList.ItemsSource = Translations;
            }
            else
            {
                var Translations = await _connection.Table<translation>().Where(i => (i.english.ToLower().Contains(e.NewTextValue.ToLower())) && (i.description == selectedGroup)).ToListAsync();
                TranslationList.ItemsSource = Translations;
            }

        }

        private SQLiteAsyncConnection _connection; 
        public Libary()
        {
            InitializeComponent();
            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();          
        }

        public Libary(string groupSelected)
        {
            InitializeComponent();
            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();
            selectedGroup = groupSelected;
        }


        protected override async void OnAppearing()         {             await _connection.CreateTableAsync<translation>();
            if (selectedGroup == null)
            {
                var Translations = await _connection.Table<translation>().ToListAsync();
                TranslationList.ItemsSource = Translations;
            }else{
                var Translations = await _connection.Table<translation>().Where(i => i.description.Equals(selectedGroup)).ToListAsync();

                TranslationList.ItemsSource = Translations;


            }                         base.OnAppearing();         } 
      

    }
}
