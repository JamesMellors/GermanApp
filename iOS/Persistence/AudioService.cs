using System;
using Xamarin.Forms;
using System.IO;
using Foundation;
using AVFoundation;

[assembly: Dependency(typeof(GermanApp.iOS.AudioService))]
namespace GermanApp.iOS
{
    public class AudioService : Persistence.IAudio
    {
        public AudioService()
        {
        }

        public void PlayAudioFile(string fileName)
        {
            string sFilePath = NSBundle.MainBundle.PathForResource
            (Path.GetFileNameWithoutExtension(fileName), Path.GetExtension(fileName));
            var url = NSUrl.FromString(sFilePath);
            var _player = AVAudioPlayer.FromUrl(url);
            _player.FinishedPlaying += (object sender, AVStatusEventArgs e) => {
                _player = null;
            };
            _player.Play();
        }
    }
}
