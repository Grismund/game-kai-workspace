using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using game_kai_workspace.Models;
using SQLite;
// using SQLite.Net;

namespace game_kai_workspace
{
    public class Database
    {
        private readonly SQLiteAsyncConnection _database;

        public Database(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Item>();
        }
        
        public Task<List<Item>> GetItemsAsync()
        {
            return _database.Table<Item>().ToListAsync();
        }
        
        public Task<List<Item>> GetObtainedItemsAsync()
        {
            return _database.QueryAsync<Item>("SELECT * FROM [Items] WHERE [Status] = 'Obtained'");
        }

        public Task<int> SaveItemAsync(Item item)
        {
            return _database.InsertAsync(item);
        }
    }
}