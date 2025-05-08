using System;

namespace DungeonExplorer
{
    public class Weapon : Item
    {
        public int Damage { get; set; }

        public Weapon(string name, int damage) : base(name)
        {
            Damage = damage;
        }

        public override void Use(Player player)
        {
            Console.WriteLine($"Used weapon: {Name} (Deals {Damage} damage)");
        }
    }
}