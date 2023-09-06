using System;
using game_kai_workspace.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace game_kai_workspace
{
    public partial class App : Application
    {
        public App ()
        {
            InitializeComponent();
            
            ItemsViewModel.SeedDatabase();
            
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

