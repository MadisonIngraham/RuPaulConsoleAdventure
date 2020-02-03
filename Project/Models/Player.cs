using System.Collections.Generic;
using ConsoleAdventure.Project.Interfaces;

namespace ConsoleAdventure.Project.Models
{
  public class Player : IPlayer
  {
    public string Name { get; set; }
    public List<Item> Inventory { get; set; }

    bool IPlayer._consoledAsh { get; set; } = false;
    bool IPlayer._lashesOn { get; set; } = false;
    bool IPlayer._haveFan { get; set; } = false;
    bool IPlayer._winDanceOff { get; set; } = false;
    bool IPlayer._impressChad { get; set; } = false;



    public Player(string name)
    {
      Name = name;
      Inventory = new List<Item>();
    }
  }
}