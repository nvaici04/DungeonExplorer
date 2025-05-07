using System;
using System.Diagnostics;

namespace DungeonExplorer
{
    public static class Testing
    {
        public static void RunAllTests()
        {
            TestPlayerHealthIncrease();
            TestMonsterDamage();
            TestItemPickup();
            TestRoomNavigation();

            Console.WriteLine("All tests completed.");
        }

        private static void TestPlayerHealthIncrease()
        {
            Player player = new Player("TestHero", 80);
            Potion potion = new Potion("Health Potion", 20);
            potion.Use(player);
            Debug.Assert(player.Health == 100, "Player health should be 100 after using potion.");
            Console.WriteLine("✔ TestPlayerHealthIncrease passed");
        }

        private static void TestMonsterDamage()
        {
            Player player = new Player("TestHero", 100);
            Monster monster = new Monster("TestGoblin", 30);
            monster.Attack(player);
            Debug.Assert(player.Health == 85, "Player should have 85 health after monster attack.");
            Console.WriteLine("✔ TestMonsterDamage passed");
        }

        private static void TestItemPickup()
        {
            Player player = new Player("TestHero", 100);
            Weapon sword = new Weapon("Test Sword", 10);
            player.PickUpItem(sword);
            Debug.Assert(player.Inventory.GetItems().Count == 1, "Player should have one item in inventory.");
            Console.WriteLine("✔ TestItemPickup passed");
        }

        private static void TestRoomNavigation()
        {
            Room room1 = new Room("Room1", "First room");
            Room room2 = new Room("Room2", "Second room");
            room1.ConnectedRooms.Add(room2);
            Debug.Assert(room1.ConnectedRooms.Contains(room2), "Room1 should connect to Room2.");
            Console.WriteLine("✔ TestRoomNavigation passed");
        }
    }
}
