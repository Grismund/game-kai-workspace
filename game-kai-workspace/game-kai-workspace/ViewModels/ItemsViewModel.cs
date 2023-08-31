using System.Collections.ObjectModel;
using System.Linq;
using game_kai_workspace.Models;

namespace game_kai_workspace.ViewModels
{
    public class ItemsViewModel
    {
        public ObservableCollection<Item> Items { get; } = new ObservableCollection<Item>
        {
            new Item { Id = "1", Name = "Briefcase", ImageSource = "briefcase.png", Description="Your trusty old case. Battered and worn.", Status = Item.ItemStatus.Obtained },
            new Item { Id = "2", Name = "9mm Handgun", ImageSource = "gun.png", Description="Standard issue for an investigator doing dangerous work.", Status = Item.ItemStatus.Obtained },
            new Item { Id = "3", Name = "Notepad", ImageSource = "notepad.png", Description="Your notes are comprehensive.", Status = Item.ItemStatus.Obtained },
            new Item { Id = "4", Name = "Pills", ImageSource = "pills.png", Description="Probably home-brewed. What was Kai working on?", Status = Item.ItemStatus.Unobtained },
            new Item { Id = "5", Name = "SD-Card", ImageSource = "sd-card.png", Description="A secret memory card hidden in a vintage camera.", Status = Item.ItemStatus.Unobtained },
            new Item { Id = "6", Name = "Photograph", ImageSource = "portrait.png", Description="Looks like a younger version of Kai...possibly her younger sister.", Status = Item.ItemStatus.Unobtained },
        };
        
        public ObservableCollection<Item> ObtainedItems  => new ObservableCollection<Item>(Items.Where(item => item.Status == Item.ItemStatus.Obtained));
    }
}
