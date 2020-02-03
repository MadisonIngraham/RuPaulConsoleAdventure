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
      Messages.Add($"Welcome home, babe! You've entered the {_game.CurrentRoom.Name}. Sounds like Ashleigh is jamming out to Sam Smith. You notice some chocolate on the counter. Remember - you need get your lashes done and get dolled up for this party! Hurry!");
      return;
    }

    public void Welcome()
    {
      Messages.Add($"{_game.CurrentRoom.Description}");
    }


    public void Go(string direction)
    {
      if (_game.CurrentRoom.Exits.ContainsKey(direction))
      {
        Messages.Clear();
        Messages.Add("I don't walk... I strut!");
        Thread.Sleep(3000);
        Console.Clear();
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
      throw new System.NotImplementedException();
    }

    public void Look()
    {
      Messages.Clear();
      Messages.Add($"{_game.CurrentRoom.Description}");
      return;
    }

    public void Quit()
    {
      throw new System.NotImplementedException();
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
      if (_game.CurrentRoom.Items.Count == 0)
      {
        Messages.Clear();
        Messages.Add("There are no items to pick up in this room.");
      }
      _game.CurrentPlayer.Inventory.AddRange(_game.CurrentRoom.Items);
      Messages.Clear();
      Messages.Add("You picked up " + itemName);
      _game.CurrentRoom.Items.Clear();
    }
    ///<summary>
    ///No need to Pass a room since Items can only be used in the CurrentRoom
    ///Make sure you validate the item is in the room or player inventory before
    ///being able to use the item
    ///</summary>
    public void UseItem(string itemName)
    {
      if (_game.CurrentPlayer.Inventory.Count == 0)
      {
        Messages.Clear();
        Messages.Add("You don't have any items to use.");
      }
      if (_game.CurrentRoom.Name == "Ashleigh's Room" && itemName == "chocolate")
      {
        Messages.Clear();
        Messages.Add("You hand the chocolate to your withering roomate. She sniffles a thank you.");
      }
    }
  }
}