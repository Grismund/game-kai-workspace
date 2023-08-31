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

                    SeedInitialData();
                    Console.WriteLine($"Database created => { database }");
                }
                
                Console.WriteLine($"Database accessed => { database }");
                return database;
            }
        }

        private static void SeedInitialData()
        {
            var initialItems = new[]
            {
                new Item { Id = "1", Name = "Briefcase", ImageSource = "briefcase.png", Description="Your trusty old case. Battered and worn.", Status = Item.ItemStatus.Obtained },
                new Item { Id = "2", Name = "9mm Handgun", ImageSource = "gun.png", Description="Standard issue for an investigator doing dangerous work.", Status = Item.ItemStatus.Obtained },
                new Item { Id = "3", Name = "Notepad", ImageSource = "notepad.png", Description="Your notes are comprehensive.", Status = Item.ItemStatus.Obtained },
                new Item { Id = "4", Name = "Pills", ImageSource = "pills.png", Description="Probably home-brewed. What was Kai working on?", Status = Item.ItemStatus.Unobtained },
                new Item { Id = "5", Name = "SD-Card", ImageSource = "sd-card.png", Description="A secret memory card hidden in a vintage camera.", Status = Item.ItemStatus.Unobtained },
                new Item { Id = "6", Name = "Photograph", ImageSource = "portrait.png", Description="Looks like a younger version of Kai...possibly her younger sister.", Status = Item.ItemStatus.Unobtained },
            };

            foreach (var item in initialItems)
            {
                Database.SaveItemAsync(item);
            }
        }

        public App ()
        {
            InitializeComponent();
            
            Console.WriteLine("App started");
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

