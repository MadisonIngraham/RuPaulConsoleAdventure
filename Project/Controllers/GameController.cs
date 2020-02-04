using System;
using System.Collections.Generic;
using ConsoleAdventure.Project.Interfaces;
using ConsoleAdventure.Project.Models;
using System.Threading;

namespace ConsoleAdventure.Project.Controllers
{

  public class GameController : IGameController
  {
    private GameService _gameService = new GameService();
    private bool _running = true;


    static void TypeLine(string line)
    {
      for (int i = 0; i < line.Length; i++)
      {
        Console.Write(line[i]);
        System.Threading.Thread.Sleep(40); // milliseconds
      }
    }

    public void Run()
    {
      Console.WriteLine(@"
      
                                                                                                        
8 888888888o.  8 8888      88           8 888888888o      .8.       8 8888      88 8 8888         
8 8888    `88. 8 8888      88           8 8888    `88.   .888.      8 8888      88 8 8888         
8 8888     `88 8 8888      88           8 8888     `88  :88888.     8 8888      88 8 8888         
8 8888     ,88 8 8888      88           8 8888     ,88 . `88888.    8 8888      88 8 8888         
8 8888.   ,88' 8 8888      88           8 8888.   ,88'.8. `88888.   8 8888      88 8 8888         
8 888888888P'  8 8888      88           8 888888888P'.8`8. `88888.  8 8888      88 8 8888         
8 8888`8b      8 8888      88           8 8888      .8' `8. `88888. 8 8888      88 8 8888         
8 8888 `8b.    ` 8888     ,8P           8 8888     .8'   `8. `88888.` 8888     ,8P 8 8888         
8 8888   `8b.    8888   ,d8P            8 8888    .888888888. `88888. 8888   ,d8P  8 8888         
8 8888     `88.   `Y88888P'             8 8888   .8'       `8. `88888. `Y88888P'   8 888888888888 
      
      ");
      Thread.Sleep(3000);
      Console.Clear();
      TypeLine("You've recently moved to LA where the queen scene is POPPIN', henny! It's February 28, 2020... it's the season premiere for Season 12 of Ru Paul's Drag Race. You've been invited to a Ru Paul premiere party at, none other than, Chaz Chadwick's house. He is only the most sickening social media content manager at your new company and you must win him over.");
      Thread.Sleep(3000);
      Console.Clear();
      TypeLine("You need to SLAY at this party, girl. You've recruited the help of your roommate Ashleigh to help you do your fake lashes. Type 'start' to begin.");
      Thread.Sleep(3000);
      Console.Clear();
      while (_running)
      {
        _gameService.Messages.ForEach(Print);
        //NOTE clear should go here, re evaluate why it didn't work before
        GetUserInput();
      }
      Console.Clear();
      Console.WriteLine("You're still a queen to me!!!!!");
    }


    public void GetUserInput()
    {
      Console.WriteLine("What would you like to do?");
      string input = Console.ReadLine().ToLower() + " ";
      string command = input.Substring(0, input.IndexOf(" "));
      string option = input.Substring(input.IndexOf(" ") + 1).Trim();

      switch (command)
      {
        case "start":
          Console.Clear();
          _gameService.InitialEntry();
          _gameService.Look();
          break;
        case "quit":
        case "exit":
          _running = false;
          break;
        case "go":
          _gameService.Go(option);
          break;
        case "look":
          _gameService.Look();
          break;
        case "help":
          _gameService.Help();
          break;
        case "take":
          _gameService.TakeItem(option);
          break;
        case "use":
          _gameService.UseItem(option);
          break;
        case "inventory":
          _gameService.Inventory();
          break;
        case "eat":
          _gameService.Eat(option);
          _gameService.Messages.ForEach(Print);
          Console.ReadKey();
          Console.Clear();
          _running = false;
          break;
        case "drink":
          _gameService.Drink(option);
          _gameService.Messages.ForEach(Print);
          Console.ReadKey();
          Console.Clear();
          _running = false;
          break;
        case "talk":
          _gameService.Talk();
          break;
        case "amen":
          _gameService.Talk();
          break;
        case "yvie":
        case "yvie oddly":
          _gameService.WinGame();
          break;
      }
    }


    private void Print(string s)
    {
      Console.WriteLine(s);
    }
  }
}
