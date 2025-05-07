using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Room
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Item> Loot { get; set; }
        public Monster Monster { get; set; }
        public List<Room> ConnectedRooms { get; set; }

        public Room(string name, string description)
        {
            Name = name;
            Description = description;
            Loot = new List<Item>();
            ConnectedRooms = new List<Room>();
        }

        public string GetDescription()
        {
            return Description;
        }
    }
}
