using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using game_kai_workspace.Models;
using SQLite;

namespace game_kai_workspace.Services
{
    public static class ItemService
    {
        static SQLiteAsyncConnection db;
        
        static async Task Init()
        {
            if(db != null)
                return;
            
            var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Items.db");
            
            db = new SQLiteAsyncConnection(databasePath);
            
            await db.CreateTableAsync<Item>();
        }
        
        public static async Task AddItem(Item item)
        {
            await Init();

            var briefcase = new Item
            {
                Id = "1", Name = "Briefcase", ImageSource = "briefcase.png",
                Description = "Your trusty old case. Battered and worn.", Status = Item.ItemStatus.Obtained
            };

            var id = await db.InsertAsync(briefcase);
        }

        public static async Task RemoveItem(int id)
        {
            await Init();
            
            await db.DeleteAsync<Item>(id);
        }

        public static async Task <IEnumerable<Item>> GetItem()
        {
            await Init();

            var items = await db.Table<Item>().ToListAsync();

            return items;
        }
    }
}