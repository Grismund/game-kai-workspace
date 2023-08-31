using System;
using System.IO;
using game_kai_workspace.Models;
using SQLite.Net;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace game_kai_workspace
{
    public partial class App : Application
    {
        private static Database database;
        
        
        // public static SQLiteConnection DatabaseConnection { get; private set; }
        //     
        //     string databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "game-kai-workspace.db3");
        //     
        //     DatabaseConnection = new SQLiteConnection(databasePath);
        //
        //     DatabaseConnection.CreateTable<Item>();
        //
        public App ()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart ()
        {
        }

        protected override void OnSleep ()
        {
        }

        protected override void OnResume ()
        {
        }
    }
}

