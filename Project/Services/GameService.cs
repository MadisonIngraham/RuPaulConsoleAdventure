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
        Look();
        return;
      }
      Messages.Clear();
      Messages.Add("You can't go that direction in this room.");
    }
    public void Help()
    {
      Messages.Clear();
      Messages.Add(@"Available Commands
---------------------
    - Go 
    - Use
    - Take 
    - Look 
    - Drink
    - Eat
    - Talk
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
      Messages.Clear();
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
      if (found.Name == "hand fan")
      {
        _game.CurrentPlayer._haveFan = true;
      }
      return;
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
        Messages.Add("You put your hand on the back of your withering roomate and offer her the treats. She wipes her eyes and wimpers a thank you. Hugging her tight, you tell her no boy is worth these tears, henny. \nCan I get an 'amen'?");
        _game.CurrentPlayer._consoledAsh = true;
        _game.CurrentPlayer.Inventory.Remove(itemToUse);
        return;
      }

      if (_game.CurrentRoom.Name != "Ashleigh's Room" && itemName == "lashes")
      {
        Messages.Clear();
        Messages.Add("You don't really need those right now, hun. I'd just hold onto them until you're ready for Ashleigh to apply them for you. Ya know?!");
        return;
      }

      if (_game.CurrentRoom.Name == "Ashleigh's Room" && itemName == "lashes" && _game.CurrentPlayer._consoledAsh == true)
      {
        Messages.Clear();
        Messages.Add("Ashleigh is happy to help with your lashes now that she's totally over Brad! She performs a perfect place with the lashes and you can't help but BLINK FOR THESE HOES! Fierce girl!");
        _game.CurrentPlayer._lashesOn = true;
        _game.CurrentPlayer.Inventory.Remove(itemToUse);
        return;
      }

      if (_game.CurrentRoom.Name == "Ashleigh's Room" && itemName == "lashes" && _game.CurrentPlayer._consoledAsh == false)
      {
        Messages.Clear();
        Messages.Add("Girl, Is your friend CRYING right now?! You better cheer her up before you ask any favors!");
        return;
      }

      if (_game.CurrentRoom.Name != "Chaz's Main Room" && itemName == "hand fan")
      {
        Messages.Clear();
        Messages.Add("I don't need any music to bust a move, let's get it!");
        Thread.Sleep(3000);
        Console.Clear();
        Messages.Add("*vogue, vogue, fan, fan, spin, twirl and HIT!*");
        return;
      }

      if (itemName == "hand fan" && _game.CurrentPlayer._haveFan == true && _game.CurrentPlayer._lashesOn == true)
      {
        Messages.Clear();
        Messages.Add("You remember you snagged the hand fan from Ashleigh's room. And with the word of Todrick Hall to the beat, you hear... 'fan for me, fan for me!' You start voguing into the dance floor and the crowd goes wild. \nYou're twirling, you're snapping, you're fanning! You're giving it everything you've got sweetie!!! \nA girl with half brown, half blonde hair comes up to you. 'GIRL! That was incredible! You have to meet Chaz, he'd totally love you. He's in his room!");
        _game.CurrentPlayer._winDanceOff = true;
        return;
      }


      if (itemName == "hand fan" && _game.CurrentPlayer._lashesOn == false || _game.CurrentPlayer._haveFan == false)
      {
        Messages.Clear();
        Messages.Add("You start casually dancing in the middle of the dance floor, keeping it at a casual bounce. You step into the dance floor but you're not drawing any attention... Honey, you're not going to win over Chaz this way. Maybe you should go back to your house and try to find something to add to your glam factor.");
        return;
      }
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
      Messages.Add("Chocolate?! YAAASSSS! You start munch down that chocolate bar, queen! Ashleigh comes out of her room and into the kitchen... She is not happy about you eating her chocolate bar! 'YOU ATE MY CHOCOLATE?! How could you? I am never helping you with your lashes ever again!!!' Girl, that chocolate was supposed to be for your friend. Press any key to sashay away...");
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
        Messages.Add("Honey, you can't drink this.");
        return;
      }
      Messages.Clear();
      Messages.Add("Moscato?! Don't mind if I do! *glug* *glug* *glug* \nOh no! You're swaying and hiccupping... girl, you're too drunk for this party! Go to bed! Press any key to sashay away...");
    }

    public void Talk()
    {
      if (_game.CurrentRoom.Name == "Ashleigh's Room" && _game.CurrentPlayer._consoledAsh == false)
      {
        Messages.Clear();
        Messages.Add("Ashleigh says: 'You would NEVER believe the day I'm having! Brad broke up with me!!! Sis, I am crushed. I have a date with the wine bottle and choclate bar on the kitchen table tonight.'");
        return;
      }

      if (_game.CurrentRoom.Name != "Ashleigh's Room" && _game.CurrentRoom.Name != "Chaz's Room")
      {
        Messages.Clear();
        Messages.Add("There's not really anyone to talk to here.");
        return;
      }

      if (_game.CurrentRoom.Name == "Ashleigh's Room" && _game.CurrentPlayer._consoledAsh == true)
      {
        Messages.Clear();
        Messages.Add("Ashleigh says: 'Thanks girl! Where would I be without you??'");
        return;
      }

      if (_game.CurrentRoom.Name == "Chaz's Room" && _game.CurrentPlayer._winDanceOff == false)
      {
        Messages.Clear();
        Messages.Add("Chaz is throwing HELLA shade, what's his problem?! He says, 'Who do you even know here? Don't come back in here  until you're somebody worth talking to!!'");
        return;
      }

      if (_game.CurrentRoom.Name == "Chaz's Room" && _game.CurrentPlayer._winDanceOff == true)
      {
        Messages.Clear();
        Messages.Add("Chaz stands up to greet you. He says, 'There you are! Heard you threw it down out there, that's hot. But I only hangout with true Ru Paul fans only. Prepare for the final question... \nOnly real fans will know the answer to this question... which queen was the winner of last season, season 11?");
        return;
      }
    }

    public void WinGame()
    {
      Messages.Clear();
      Messages.Add("YOU ARE A WINNER! I knew you were a real fan!");
      return;
    }
  }
}
