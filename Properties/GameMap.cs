using System.Collections.Generic;
using System.Linq;

namespace DungeonExplorer
{
    public class GameMap
    {
        public List<Room> Rooms { get; set; } = new List<Room>();

        public void AddRoom(Room room)
        {
            Rooms.Add(room);
        }

        public Room GetRoom(string name)
        {
            return Rooms.FirstOrDefault(r => r.Name == name);
        }
    }
}
