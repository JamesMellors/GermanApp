using System;
using SQLite;
using System.IO;
using Xamarin.Forms;
using GermanApp.iOS;
using Foundation;

[assembly: Dependency(typeof(SQLiteDb))]

namespace GermanApp.iOS
{
    public class SQLiteDb : ISQLiteDb
    {
       
            public SQLiteAsyncConnection GetConnection()
            {
          
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(documentsPath, "GermanWords.db3"); //GetLocalFilePath("GermanWords.db3");//Path.Combine(documentsPath,"GermanWords.db3");  NSBundle.MainBundle.BundlePath
           // var pathToResoure = NSBundle.MainBundle.PathForResource(Path.GetFileNameWithoutExtension("GermanWords.db3"), Path.GetExtension("GermanWords.db3"));
          //  if (!Directory.Exists(documentsPath))
           // {
           //     Directory.CreateDirectory(documentsPath);
           //     System.IO.File.Copy(pathToResoure, documentsPath, true);

           // }
          
               return new SQLiteAsyncConnection(path);
            }


        public static string GetLocalFilePath(string filename)
        {
            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");

            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }

            string dbPath = Path.Combine(libFolder);

          //  CopyDatabaseIfNotExists(dbPath);

            return dbPath;
        }

        //h
    }
}
