using System;

namespace DungeonExplorer
{
    public abstract class Item : ICollectible
    {
        public string Name { get; set; }

        public Item(string name)
        {
            Name = name;
        }

        public abstract void Use(Player player);
    }
}