using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using game_kai_workspace.Models;
using SQLite;

namespace game_kai_workspace
{
    public static class Database
    {
        static SQLiteAsyncConnection dbConnection;
        
        static async Task InitializeDb()
        {
            if (dbConnection != null)
                return;
            
            var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ItemsDatabase.db3");
            
            dbConnection = new SQLiteAsyncConnection(databasePath);

            await dbConnection.CreateTableAsync<Item>();
            
            if (await dbConnection.Table<Item>().CountAsync() > 0)
                return;
            
            await SeedDatabase();
        }

        private static async Task SeedDatabase()
        {
            var items = new List<Item>
            {
                new Item { Name = "Briefcase", ImageSource = "briefcase.png", Description="Your trusty old case. Battered and worn.", Status = Item.ItemStatus.Obtained },
                new Item { Name = "9mm Handgun", ImageSource = "gun.png", Description="Standard issue for an investigator doing dangerous work.", Status = Item.ItemStatus.Obtained },
                new Item { Name = "Notepad", ImageSource = "notepad.png", Description="Your notes are comprehensive.", Status = Item.ItemStatus.Obtained },
                new Item { Name = "Pills", ImageSource = "pills.png", Description="Probably home-brewed. What was Kai working on?", Status = Item.ItemStatus.Unobtained },
                new Item { Name = "SD-Card", ImageSource = "sd-card.png", Description="A secret memory card hidden in a vintage camera.", Status = Item.ItemStatus.Unobtained },
                new Item { Name = "Photograph", ImageSource = "portrait.png", Description="Looks like a younger version of Kai...possibly her younger sister.", Status = Item.ItemStatus.Unobtained },
            };
            
            await dbConnection.InsertAllAsync(items);
        }
        
        // Task or Task<List<Item>> or Task<IEnumerable<Item>>? What's the difference?
        public static async Task<IEnumerable<Item>> GetItems()
        {
            await InitializeDb();
            
            var items = await dbConnection.Table<Item>().ToListAsync();
            
            return items;
        }
        
        public static async Task UpdateItem(Item item)
        {
            await InitializeDb();
            
            await dbConnection.UpdateAsync(item);
        }
    }
}