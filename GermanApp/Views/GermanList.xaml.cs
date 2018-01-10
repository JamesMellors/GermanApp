using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace GermanApp.Views
{
    public partial class GermanList : ContentPage
    {
        public GermanList()
        {
            InitializeComponent();

            var names = new List<string>
            {
                "James",
                "test"
            };
            ListView.ItemsSource = names;
        }
    }
}
