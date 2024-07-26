using System;
using System.IO;
using FinalProject.Droid.SQLite;
using FinalProject.SQLite;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLite_Android))]
namespace FinalProject.Droid.SQLite
{
    public class SQLite_Android : ISQLite
    {
        public SQLite_Android()
        {
        }
        #region ISQLite implementation
        public SQLiteAsyncConnection GetConnection()
        {
            var sqliteName = "SampleDB.db3";
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);// Documents folder
            var path = Path.Combine(documentsPath, sqliteName);
            // Create the connection
            var connection = new SQLiteAsyncConnection(path);
            // Return the database connection
            return connection;
        }
        #endregion
    }
}