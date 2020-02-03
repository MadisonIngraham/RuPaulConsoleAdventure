using ConsoleAdventure.Project.Interfaces;
using System.Collections.Generic;


namespace ConsoleAdventure.Project.Models
{
  class Game : IGame
  {
    public IRoom CurrentRoom { get; set; }
    public IPlayer CurrentPlayer { get; set; }
    public List<Item> RoomInventory { get; set; } = new List<Item>();


    public void Setup()
    {
      Player Player1 = new Player("Player 1");

      Room MyKitchen = new Room("Kitchen", "Enter the kitchen of your house. There's a dining room table with a big window that opens up the space. Look! A chocolate bar!");
      Room MyRoom = new Room("My Room", "Enter your room. Directly in front of you is your bed, pushed up against the wall near the corner of the room. Slightly to your left is your bedside table with the fake lashes for tonight.");
      Room AshleighRoom = new Room("Ashleigh's Room", "Enter Ashleigh's room. Directly to your right, crumbled up on the bed, lay a crying Ashleigh.");
      Room ChazMainRoom = new Room("Chaz's Main Room", "Enter the main room of Chaz Chadwick's house. It's a big house with high ceilings. To your right, there is a tall oak entertainment system with no TV. To the left is the kitchen, packed with people screaming along the Todrick Hall song playing loudly.");
      Room ChazRoom = new Room("Chaz's Room", "Enter Chaz's room. Through hanging beads at the door, of course. The lights are dim and Chaz sits across the room in a pink fluffy chair surrounded by his queens.");

      MyKitchen.Exits.Add("east", MyRoom);
      MyKitchen.Exits.Add("west", AshleighRoom);
      MyKitchen.Exits.Add("south", ChazMainRoom);
      MyRoom.Exits.Add("west", MyKitchen);
      AshleighRoom.Exits.Add("east", MyKitchen);
      ChazMainRoom.Exits.Add("west", ChazRoom);
      ChazMainRoom.Exits.Add("south", MyKitchen);
      ChazRoom.Exits.Add("east", ChazMainRoom);

      MyKitchen.Items.Add(new Item("chocolate", "Hershey's chocolate bar"));
      MyRoom.Items.Add(new Item("lashes", "glam fake lashes and glue"));
      AshleighRoom.Items.Add(new Item("hand fan", "black handfan with white Chinese design"));

      CurrentRoom = MyKitchen;
      CurrentPlayer = Player1;
    }

    public Game()
    {
      Setup();
    }
  }
}