using SQLite.Net.Attributes;

namespace game_kai_workspace.Models
{
    public class Item
    {
        [PrimaryKey, AutoIncrement]
        public string Id { get; set; }
        public string Name { get; set; }
        public string ImageSource { get; set; }
        public string Description { get; set; }
        public ItemStatus Status { get; set; }

        public enum ItemStatus
        {
            Obtained,
            Unobtained,
            Used,
            Lost,
        }
    }
}