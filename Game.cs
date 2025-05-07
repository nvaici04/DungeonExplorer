using System;

namespace DungeonExplorer
{
    internal class Game
    {
        private Player player;
        private GameMap map;
        private Room currentRoom;

        public Game()
        {
            map = new GameMap();

            Console.Write("Enter your hero's name: ");
            string playerName = Console.ReadLine();
            player = new Player(playerName, 100);

            var room1 = new Room("Entrance", "You are in the entrance of the dungeon.");
            var room2 = new Room("Hall", "You have entered a long, dark hallway.");
            var room3 = new Room("Chamber", "This chamber smells of sulfur and danger.");

            room1.ConnectedRooms.Add(room2);
            room2.ConnectedRooms.Add(room1);
            room2.ConnectedRooms.Add(room3);
            room3.ConnectedRooms.Add(room2);

            room1.Loot.Add(new Weapon("Rusty Sword", 10));
            room2.Monster = new Monster("Goblin", 30);
            room3.Monster = new Monster("Dragon", 100);

            map.AddRoom(room1);
            map.AddRoom(room2);
            map.AddRoom(room3);

            currentRoom = room1;
        }

        public void Start()
        {
            bool playing = true;

            while (playing)
            {
                Console.WriteLine($"\nYou are in: {currentRoom.Name}");
                Console.WriteLine(currentRoom.GetDescription());

                player.DisplayStatus();

                if (currentRoom.Monster != null)
                {
                    Console.WriteLine($"A wild {currentRoom.Monster.Name} appears!");

                    while (player.Health > 0 && currentRoom.Monster != null && currentRoom.Monster.Health > 0)
                    {
                        Console.WriteLine("Do you want to attack or flee? (attack/flee): ");
                        string action = Console.ReadLine();

                        if (action.ToLower() == "attack")
                        {
                            player.Attack(currentRoom.Monster);

                            if (currentRoom.Monster.Health > 0)
                                currentRoom.Monster.Attack(player);
                        }
                        else if (action.ToLower() == "flee")
                        {
                            Console.WriteLine("You fleed to the previous room!");
                            currentRoom = currentRoom.ConnectedRooms[0];
                            break;
                        }

                        if (player.Health <= 0)
                        {
                            Console.WriteLine("You have been defeated!");
                            Console.Write("Do you want to play again? (yes/no): ");
                            string restartChoice = Console.ReadLine().ToLower();

                            if (restartChoice == "yes")
                            {
                                Console.Clear();
                                new Game().Start();
                                return;
                            }
                            else
                            {
                                Console.WriteLine("Thanks for playing!");
                                Environment.Exit(0);
                            }
                        }
                    }

                    if (currentRoom.Monster != null && currentRoom.Monster.Health <= 0)
                    {
                        Console.WriteLine($"You defeated the {currentRoom.Monster.Name}!");
                        var loot = currentRoom.Monster.DropLoot();
                        Console.WriteLine($"The {currentRoom.Monster.Name} dropped a {loot.Name}!");
                        player.PickUpItem(loot);
                        currentRoom.Monster = null;
                    }
                }

                if (currentRoom.Loot.Count > 0)
                {
                    Console.WriteLine("You found some items in this room:");
                    foreach (var item in currentRoom.Loot)
                    {
                        Console.WriteLine("- " + item.Name);
                    }

                    Console.Write("Do you want to pick them up? (yes/no): ");
                    string choice = Console.ReadLine();
                    if (choice.ToLower() == "yes")
                    {
                        foreach (var item in currentRoom.Loot)
                        {
                            player.PickUpItem(item);
                        }
                        currentRoom.Loot.Clear();
                    }
                }

                Console.WriteLine("\nWhat would you like to do?");
                Console.WriteLine("1. View Inventory");
                Console.WriteLine("2. Move to another room");
                Console.WriteLine("3. Quit");
                Console.Write("Choice: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        var inventoryItems = player.Inventory.GetItems();
                        if (inventoryItems.Count == 0)
                        {
                            Console.WriteLine("Your inventory is empty.");
                            break;
                        }

                        Console.WriteLine("Your Inventory:");
                        for (int i = 0; i < inventoryItems.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {inventoryItems[i].Name}");
                        }

                        Console.Write("Enter the number of the item you want to use (or press Enter to go back): ");
                        string inputItem = Console.ReadLine();
                        if (int.TryParse(inputItem, out int itemIndex) &&
                            itemIndex > 0 && itemIndex <= inventoryItems.Count)
                        {
                            var selectedItem = inventoryItems[itemIndex - 1];
                            selectedItem.Use(player);

                            // Optional: Remove potion after use
                            if (selectedItem is Potion)
                            {
                                inventoryItems.RemoveAt(itemIndex - 1);
                            }
                        }
                        else if (!string.IsNullOrWhiteSpace(inputItem))
                        {
                            Console.WriteLine("Invalid selection.");
                        }
                        break;
                    case "2":
                        Console.WriteLine("Connected rooms:");
                        for (int i = 0; i < currentRoom.ConnectedRooms.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {currentRoom.ConnectedRooms[i].Name}");
                        }
                        Console.Write("Enter room number to move to: ");
                        if (int.TryParse(Console.ReadLine(), out int roomIndex) &&
                            roomIndex > 0 && roomIndex <= currentRoom.ConnectedRooms.Count)
                        {
                            currentRoom = currentRoom.ConnectedRooms[roomIndex - 1];
                        }
                        else
                        {
                            Console.WriteLine("Invalid room selection.");
                        }
                        break;
                    case "3":
                        playing = false;
                        Console.WriteLine("Thanks for playing!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
