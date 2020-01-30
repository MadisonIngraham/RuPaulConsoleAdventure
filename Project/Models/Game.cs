using ConsoleAdventure.Project.Interfaces;
using System.Collections.Generic;


namespace ConsoleAdventure.Project.Models
{
  class Game : IGame
  {
    public IRoom CurrentRoom { get; set; }
    public IPlayer CurrentPlayer { get; set; }


    public void Setup()
    {
      Player Player1 = new Player("Player 1");

      Room MyKitchen = new Room("Kitchen", "Enter the kitchen of your house. There's a dining room table with a big window that opens up the space. To the right, there's the sink. The counter wraps around tight to the corner of the room and extends to the refridgerator.");
      Room MyRoom = new Room("My Room", "Enter your room. Directly in front of you is your bed, pushed up against the wall near the corner of the room. Slightly to your left is your bedside table.");
      Room AshleighRoom = new Room("Ashleigh's Room", "Enter Ashleigh's room. Directly to your right, crumbled up on the bed, lay a crying Ashleigh.");
      Room ChazMainRoom = new Room("Chaz's Main Room", "Enter the main room of Chaz Chadwick's house. It's a big house with high ceilings. To your right, there is a tall oak entertainment system with no TV. To the left is the kitchen, packed with people screaming along the Todrick Hall song playing loudly.");
      Room ChazRoom = new Room("Chaz's Room", "Enter Chaz's room. Through hanging beads at the door, of course. The lights are dim and Chaz sits across the room in a pink fluffy chair surrounded by his queens.");

      MyKitchen.Exits.Add("My Room", MyRoom);
      MyKitchen.Exits.Add("Ashleigh's Room", AshleighRoom);
      MyKitchen.Exits.Add("Chaz's Main Room", ChazMainRoom);
      MyRoom.Exits.Add("Kitchen", MyKitchen);
      AshleighRoom.Exits.Add("Kitchen", MyKitchen);
      ChazMainRoom.Exits.Add("Chaz's Room", ChazRoom);
      ChazMainRoom.Exits.Add("Kitchen", MyKitchen);
      ChazRoom.Exits.Add("Chaz's Main Room", ChazMainRoom);

      CurrentRoom = MyKitchen;
      CurrentPlayer = Player1;
    }

    public Game()
    {
      Setup();
    }
  }
}