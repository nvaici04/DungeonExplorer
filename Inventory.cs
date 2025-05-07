using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Inventory
    {
        private List<Item> items = new List<Item>();

        public void AddItem(Item item)
        {
            items.Add(item);
        }

        public List<Item> GetItems()
        {
            return items;
        }

        public Item GetItemByName(string name)
        {
            return items.Find(i => i.Name == name);
        }
    }
}