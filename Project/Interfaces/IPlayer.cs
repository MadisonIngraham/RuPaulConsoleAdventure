using System.Collections.Generic;
using ConsoleAdventure.Project.Models;

namespace ConsoleAdventure.Project.Interfaces
{
  public interface IPlayer
  {
    string Name { get; set; }
    List<Item> Inventory { get; set; }
    bool _consoledAsh { get; set; }
    bool _lashesOn { get; set; }
    bool _haveFan { get; set; }
    bool _winDanceOff { get; set; }
    bool _impressChad { get; set; }
  }
}
