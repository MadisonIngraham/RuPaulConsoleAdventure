using System.Collections.Generic;
using ConsoleAdventure.Project.Interfaces;
using ConsoleAdventure.Project.Models;
using System;
using System.Threading;

namespace ConsoleAdventure.Project
{
  public class GameService : IGameService
  {
    private IGame _game { get; set; }

    public List<string> Messages { get; set; }
    public GameService()
    {
      _game = new Game();
      Messages = new List<string>();
    }


    public void InitialEntry()
    {
      Messages.Add($"Welcome home, queen! Sounds like Ashleigh is jamming out to Sam Smith. Remember - you need get your lashes done and get dolled up for this party! Hurry!");
      return;
    }


    public void Go(string direction)
    {
      if (_game.CurrentRoom.Exits.ContainsKey(direction))
      {
        Messages.Clear();
        Messages.Add("I don't walk... I strut!");
        Thread.Sleep(3000);
        Console.Clear(); //NOTE console interactions should be through the controller
        _game.CurrentRoom = _game.CurrentRoom.Exits[direction];
        return;
      }
      Messages.Clear();
      Messages.Add("You can't go that direction in this room.");
    }
    public void Help()
    {
      Messages.Clear();
      Messages.Add(@"Available Commands
----------------------------
    - Go 
    - Use
    - Take 
    - Look 
    - Inventory
    - Help 
    - Quit
      ");
      return;
    }

    public void Inventory()
    {
      Messages.Clear();
      Messages.Add("Your inventory: ");
      foreach (var item in _game.CurrentPlayer.Inventory)
      {
        Messages.Add($"- {item.Name}");
      }
      return;
    }

    public void Look()
    {
      Messages.Add($"{_game.CurrentRoom.Description}");
      Messages.Add("Items in this room:");
      foreach (var item in _game.CurrentRoom.Items)
      {
        Messages.Add($"- {item.Name}");
      }
      return;
    }

    ///<summary>
    ///Restarts the game 
    ///</summary>
    public void Reset()
    {
      throw new System.NotImplementedException();
    }

    public void Setup(string playerName)
    {
      throw new System.NotImplementedException();
    }
    ///<summary>When taking an item be sure the item is in the current room before adding it to the player inventory, Also don't forget to remove the item from the room it was picked up in</summary>
    public void TakeItem(string itemName)
    {
      Item found = _game.CurrentRoom.Items.Find(i => i.Name.ToLower() == itemName);
      if (found == null)
      {
        Messages.Clear();
        Messages.Add("No such item, henny.");
        return;
      }
      _game.CurrentPlayer.Inventory.Add(found);
      Messages.Clear();
      Messages.Add("You picked up " + itemName);
      _game.CurrentRoom.Items.Remove(found);
    }
    ///<summary>
    ///No need to Pass a room since Items can only be used in the CurrentRoom
    ///Make sure you validate the item is in the room or player inventory before
    ///being able to use the item
    ///</summary>
    public void UseItem(string itemName)
    {
      Item itemToUse = _game.CurrentPlayer.Inventory.Find(i => i.Name.ToLower() == itemName);
      if (itemToUse == null)
      {
        Messages.Clear();
        Messages.Add("You don't have that item, girl.");
        return;
      }

      if (_game.CurrentRoom.Name == "Ashleigh's Room" && itemName == "chocolate" || itemName == "wine")
      {
        Messages.Clear();
        Messages.Add("You put your hand on the back of your withering roomate. She sniffles that her boyfriend had just broken up with her that afternoon. 'Brad doesn't even deserve you, don't waste tears on him, girl.' Enjoy this treat on me!");
        _game.CurrentPlayer._consoledAsh = true;
        _game.CurrentPlayer.Inventory.Remove(itemToUse);
        return;
      }

      if (_game.CurrentRoom.Name == "Ashleigh's Room" && itemName == "lashes" && _game.CurrentPlayer._consoledAsh == true)
      {
        Messages.Clear();
        Messages.Add("Ashleigh is happy to help with your lashes now that she's totally over Brad! She glues on your lashes PERFECTLY!");
        _game.CurrentPlayer._lashesOn = true;
        _game.CurrentPlayer.Inventory.Remove(itemToUse);
        return;
      }
      Messages.Clear();
      Messages.Add("Hey! Is your friend crying, GIRL?!Cheer her up before you ask any favors.");
      return;
    }


    public void Eat(string itemName)
    {
      Item itemToEat = _game.CurrentPlayer.Inventory.Find(i => i.Name.ToLower() == itemName);
      if (itemToEat == null)
      {
        Messages.Clear();
        Messages.Add("You don't have that item, sis.");
        return;
      }

      if (itemName != "chocolate")
      {
        Messages.Clear();
        Messages.Add("Honey, you cannot eat this.");
        return;
      }
      Messages.Clear();
      Messages.Add("Hershey's chocolate! My favorite! You start munching down the chocolate bar... Ashleigh comes storming out of her room. 'YOU ATE MY CHOCOLATE?! How could you? I am never helping you with your lashes ever again!!!");
      Messages.Add("That chocolate was supposed to be for your friend, sis. You lose.");
      return;
    }

    public void Drink(string itemName)
    {
      Item itemToDrink = _game.CurrentPlayer.Inventory.Find(i => i.Name.ToLower() == itemName);
      if (itemToDrink == null)
      {
        Messages.Clear();
        Messages.Add("You don't have that item, sis.");
        return;
      }

      if (itemName != "wine")
      {
        Messages.Clear();
        Messages.Add("Honey, you cannot drink this.");
        return;
      }
      Messages.Clear();
      Messages.Add("Moscato?! Don't mind if I do! *glug* *glug* *glug* \nAshleigh comes out of her room. 'That wine was for me to watch the Bachelor tonight!! How could you? I am never helping you with your lashes ever again!!!");
      Messages.Add("That wine was supposed to be for your friend, sis. You lose.");
      return;
    }

    public void Quit()
    {
      System.Environment.Exit(0);
    }
  }
}