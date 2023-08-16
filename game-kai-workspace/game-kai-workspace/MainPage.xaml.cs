using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using PropertyChangingEventArgs = Xamarin.Forms.PropertyChangingEventArgs;

namespace game_kai_workspace
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        string[] options;
        
        async void OnButtonClicked(object sender, EventArgs e)
        {
           await Navigation.PushModalAsync(new InventoryModal());
        }
        
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            
            await mainText.FadeTo(0, 0);
            await mainText.FadeTo(1, 3000);
        }
        
        private void OptionSelected(object sender, EventArgs e)
        {
            var selectedOptionIndex = picker.SelectedIndex;
            
            options = new string[]
            {
                "You gently pat the lazy cat on the head. You notice the collar is torn. There's a bit of blood on the name tag. \"Zephyr.\"",
                "It's an old-fashioned camera, but there's an unusual slot on the side. You retrieve a mysterious SD card. It could have clues.",
                "\"Street Fighter\" is slotted. Probably nothing to see here.",
                "You lift the phone. Moments after, you hear the dial tone, you think you hear a faint click. It's probably tapped.",
                "The beakers smell distinctly chemical. The liquid's color matches a bottle of pills next to them. Perhaps a home-brewed medicine?",
                "You put the tape into the player. It's a home video. You see Kai working at her desk. She turns around and smiles, the camera drops, and the tape plays static.",
                "This sushi is old, and the cat hasn't touched it. Probably not a good idea. As you toss it in the trash you notice a picture in the waste bin. A young girl. Kai's daughter?"
            };

            mainText.Text = options[selectedOptionIndex];
        }
    }
}

