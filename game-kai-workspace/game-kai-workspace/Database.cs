using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using game_kai_workspace.Models;
using SQLite;
using SQLite.Net;

namespace game_kai_workspace
{
    public class Database
    {
        private readonly SQLiteConnection _database;

        public Database(string dbPath)
        {
            _database = new SQLiteConnection(dbPath);
            _database.CreateTable<Item>();
        }
        
        public Task<List<Item>> GetItemsAsync()
        {
            return _database.Table<Item>().ToList();
        }
        
        public Task<List<Items>> GetObtainedItemsAsync()
        {
            return _database.Query<Items>("SELECT * FROM [Items] WHERE [Status] = "Obtained"");
        }
    }
}