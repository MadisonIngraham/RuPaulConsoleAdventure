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

      Room MyKitchen = new Room("Kitchen", "You've catwalked into the kitchen, girl. There are two doors to the east and west. Check out what's on the table!");
      Room MyRoom = new Room("My Room", "You've entered your room. Directly in front of you is your bed, pushed up against the wall near the corner of the room. Slightly to your left is your bedside table. \nKeep your eye on the prize - get ready for the party!");
      Room AshleighRoom = new Room("Ashleigh's Room", "Enter Ashleigh's room. Directly to your right, sitting at the edge of her bed, sits Ashleigh. Ask if she can still help with your lashes!");
      Room ChazMainRoom = new Room("Chaz's Main Room", "Girl! You're in Chaz Chadwick's house! It's a big house with high ceilings. To your right, there is a tall oak entertainment system with no TV. To the left is the kitchen, packed with divas. Make yourself seen, henny! This is YOUR TIME!");
      Room ChazRoom = new Room("Chaz's Room", "You are totally walking into Chaz's room. Through hanging beads at the door, so drama. The lights are dim and Chaz sits across the room in a pink fluffy chair surrounded by his queens. \nYou should say something to him.");

      MyKitchen.Exits.Add("east", MyRoom);
      MyKitchen.Exits.Add("west", AshleighRoom);
      MyKitchen.Exits.Add("south", ChazMainRoom);
      MyRoom.Exits.Add("west", MyKitchen);
      AshleighRoom.Exits.Add("east", MyKitchen);
      ChazMainRoom.Exits.Add("west", ChazRoom);
      ChazMainRoom.Exits.Add("south", MyKitchen);
      ChazRoom.Exits.Add("east", ChazMainRoom);

      MyKitchen.Items.Add(new Item("chocolate", "Hershey's chocolate bar"));
      MyKitchen.Items.Add(new Item("wine", "bottle of Barefoot moscato"));
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