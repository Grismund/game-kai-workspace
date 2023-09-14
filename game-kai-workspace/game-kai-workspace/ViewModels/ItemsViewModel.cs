using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using game_kai_workspace.Models;

namespace game_kai_workspace.ViewModels
{
    public sealed class ItemsViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Item> Items { get; } = new ObservableCollection<Item>();
        
        public ObservableCollection<Item> ObtainedItems  => new ObservableCollection<Item>(Items.Where(item => item.Status == Item.ItemStatus.Obtained));

        public ItemsViewModel()
        {
            LoadItems();
        }

        private async void LoadItems()
        {
            var items = await Database.GetItems();
            foreach (var item in items)
            {
                Items.Add(item);
            }
        }

        public static async void UpdateItem(Item item)
        {
            await Database.UpdateItem(item);
        }
        
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
