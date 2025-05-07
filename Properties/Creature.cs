using System;

namespace DungeonExplorer
{
    public abstract class Creature : IDamageable
    {
        public string Name { get; set; }
        public int Health { get; set; }

        public Creature(string name, int health)
        {
            Name = name;
            Health = health;
        }

        public virtual void TakeDamage(int amount)
        {
            Health -= amount;
            Console.WriteLine($"{Name} took {amount} damage. Health: {Health}");
        }

        public virtual void Attack(Creature target)
        {
            Console.WriteLine($"{Name} attacks {target.Name}!");
            target.TakeDamage(10);
        }
    }
}