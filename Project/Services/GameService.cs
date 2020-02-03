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
      Messages.Add($"Welcome home, babe! You've entered the {_game.CurrentRoom.Name}. Sounds like Ashleigh is jamming out to Sam Smith. You notice there's a bottle of wine and some chocolate on the counter. Remember - you need get your lashes done\n and get dolled up for this party! Hurry!");
      return;
    }

    public void Welcome()
    {
      Messages.Add($"Welcome to {_game.CurrentRoom.Name}!");
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
      throw new System.NotImplementedException();
    }

    public void Inventory()
    {
      throw new System.NotImplementedException();
    }

    public void Look()
    {
      throw new System.NotImplementedException();
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
      throw new System.NotImplementedException();
    }
    ///<summary>
    ///No need to Pass a room since Items can only be used in the CurrentRoom
    ///Make sure you validate the item is in the room or player inventory before
    ///being able to use the item
    ///</summary>
    public void UseItem(string itemName)
    {
      throw new System.NotImplementedException();
    }
  }
}