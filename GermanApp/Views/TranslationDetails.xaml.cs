using System;
using GermanApp.Persistence;
using Xamarin.Forms;



namespace GermanApp.Views
{
    public partial class TranslationDetails : ContentPage
    {
        translation Trans = new translation();
      
        public TranslationDetails(translation word)
        {
            if(word == null){
                throw new ArgumentNullException();
            }

            BindingContext = word;
            Trans = word;
            InitializeComponent();
        }

    
        void Handle_Clicked(object sender, System.EventArgs e)
        {

            if( Trans.english != null){
            
            var File = Trans.english + ".mp3";

            File = File.Replace(" ", "");

            DependencyService.Get<IAudio>().PlayAudioFile(File);
            }
        }
    }
}
