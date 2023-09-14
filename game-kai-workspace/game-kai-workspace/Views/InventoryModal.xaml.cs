using System;
using game_kai_workspace.ViewModels;
using Xamarin.Forms.Xaml;

namespace game_kai_workspace
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InventoryModal
    {
        public InventoryModal(ItemsViewModel viewModel)
        {
            InitializeComponent();
            
            BindingContext = viewModel;
        }

        private async void OnCloseInventoryClicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
        
        
    }
}