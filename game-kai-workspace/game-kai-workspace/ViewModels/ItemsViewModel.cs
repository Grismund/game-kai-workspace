using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using game_kai_workspace.Models;
using SQLite;
using Path = System.IO.Path;

namespace game_kai_workspace.ViewModels
{
    public class ItemsViewModel
    {
        static SQLiteAsyncConnection db;
        static async Task Init()
        {
            // TODO: Not sure the LocalApplicationData path is correct
            
            if (db != null)
                return;
            // Specify the path
            var databasePath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), "MyData.db");
            // Create the connection
            db = new SQLiteAsyncConnection(databasePath);
            // Create the tables
            await db.CreateTableAsync<Item>();
        }

        public static async Task SeedDatabase()
        {
            await Init();
            
            // if (await db.Table<Item>().CountAsync() == 0)
            // {
            await db.InsertAsync(new Item { Id = "1", Name = "Briefcase", ImageSource = "briefcase.png", Description="Your trusty old case. Battered and worn.", Status = Item.ItemStatus.Obtained });
            await db.InsertAsync(new Item { Id = "2", Name = "9mm Handgun", ImageSource = "gun.png", Description="Standard issue for an investigator doing dangerous work.", Status = Item.ItemStatus.Obtained });
            await db.InsertAsync(new Item { Id = "3", Name = "Notepad", ImageSource = "notepad.png", Description="Your notes are comprehensive.", Status = Item.ItemStatus.Obtained });
            await db.InsertAsync(new Item { Id = "4", Name = "Pills", ImageSource = "pills.png", Description="Probably home-brewed. What was Kai working on?", Status = Item.ItemStatus.Unobtained });
            await db.InsertAsync(new Item { Id = "5", Name = "SD-Card", ImageSource = "sd-card.png", Description="A secret memory card hidden in a vintage camera.", Status = Item.ItemStatus.Unobtained });
            await db.InsertAsync(new Item { Id = "6", Name = "Photograph", ImageSource = "portrait.png", Description="Looks like a younger version of Kai...possibly her younger sister.", Status = Item.ItemStatus.Unobtained });
            // }
        }
        
        public static async Task ObtainItem(Item item)
        {
            await Init();
            
            // write a query to update the item;
            await db.UpdateAsync(item);
        }
        
        public static async Task<IEnumerable<Item>> GetObtainedItems()
        {
            await Init();
            
            var items = await db.Table<Item>().ToListAsync();
            
            return items.Where(item => item.Status == Item.ItemStatus.Obtained);
        }
    }
}
