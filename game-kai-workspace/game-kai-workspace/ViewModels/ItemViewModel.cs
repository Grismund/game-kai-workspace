using System.Collections.ObjectModel;
using game_kai_workspace.Models;

namespace game_kai_workspace.ViewModels
{
    public class ItemViewModel
    {
        public ObservableCollection<Item> Items { get; }
        
        public ItemViewModel()
        {
            Items = new ObservableCollection<Item>
            {
                new Item { Id = "1", Name = "Briefcase", Description = "Your trusty old case. Battered and worn.", Status = Item.ItemStatus.Obtained },
                new Item { Id = "2", Name = "9mm Handgun", Description = "Standard issue for an investigator doing dangerous work.", Status = Item.ItemStatus.Obtained },
                new Item { Id = "3", Name = "Notepad", Description = "Your notes are comprehensive.", Status = Item.ItemStatus.Obtained },
                new Item { Id = "4", Name = "Pills", Description = "Probably home-brewed. What was Kai working on?", Status = Item.ItemStatus.Unobtained },
                new Item { Id = "5", Name = "Photograph", Description = "Looks like a younger version of Kai...possibly her younger sister.", Status = Item.ItemStatus.Unobtained },
                new Item { Id = "6", Name = "SD-Card", Description = "A secret memory card hidden in a vintage camera.", Status = Item.ItemStatus.Unobtained },
            };
        }
    }
}
