using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace game_kai_workspace
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InventoryModal : ContentPage
    {
        public InventoryModal()
        {
            InitializeComponent();
        }

        async private void OnButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
            
        }
    }
}