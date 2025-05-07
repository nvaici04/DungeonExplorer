using System;

namespace DungeonExplorer
{
    public class Potion : Item
    {
        public int HealAmount { get; set; }

        public Potion(string name, int healAmount) : base(name)
        {
            HealAmount = healAmount;
        }

        public override void Use(Player player)
        {
            player.Health += HealAmount;
            Console.WriteLine($"Used potion: {Name} (Restored {HealAmount} health)");
        }
    }
}