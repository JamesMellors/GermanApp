using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using Foundation;
using UIKit;

namespace GermanApp.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {

       
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new App());

            CopyFileInBundleToDocumentsFolder("GermanWords.db3");

            return base.FinishedLaunching(app, options);
        }


        private void CopyFileInBundleToDocumentsFolder(
       String filename)
        {
            //---path to Documents folder---
            var documentsFolderPath =
                Environment.GetFolderPath(
                    Environment.SpecialFolder.MyDocuments);

            //---destination path for file in the Documents
            // folder---
            var destinationPath =
                Path.Combine(documentsFolderPath, filename);

            //---path of source file---
            var sourcePath =
                Path.Combine(NSBundle.MainBundle.BundlePath,
                filename);

            //---print for verfications---
            Console.WriteLine(destinationPath);
            Console.WriteLine(sourcePath);

            try
            {
                //---copy only if file does not exist---
                if (!File.Exists(destinationPath))
                {
                    File.Copy(sourcePath, destinationPath);
                }
                else
                {
                    Console.WriteLine("File already exists");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
