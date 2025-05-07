using System;

namespace DungeonExplorer
{
    public class Monster : Creature
    {
        public Monster(string name, int health) : base(name, health) { }

        public override void Attack(Creature target)
        {
            Console.WriteLine($"{Name} snarls and attacks {target.Name} fiercely!");
            target.TakeDamage(15);
        }

        public Item DropLoot()
        {
            return new Potion("Dropped Potion", 15);
        }
    }
}
