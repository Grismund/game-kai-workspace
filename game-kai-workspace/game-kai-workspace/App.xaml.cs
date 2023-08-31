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
        
        public static Database Database
        {
            get
            {
                if (database == null)
                {
                    database = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "game-kai-workspace.db3"));
                }

                return database;
            }
        }

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

