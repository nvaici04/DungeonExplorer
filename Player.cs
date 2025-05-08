using System;

namespace DungeonExplorer
{
    public class Player : Creature
    {
        public Inventory Inventory { get; set; }

        public Player(string name, int health) : base(name, health)
        {
            Inventory = new Inventory();
        }

        public void PickUpItem(Item item)
        {
            Inventory.AddItem(item);
        }

        public void DisplayStatus()
        {
            Console.WriteLine($"Player Name: {Name}");
            Console.WriteLine($"Health: {Health}");

            Console.WriteLine("Inventory:");
            foreach (var item in Inventory.GetItems())
            {
                Console.WriteLine($"- {item.Name}");
            }
        }
    }
}