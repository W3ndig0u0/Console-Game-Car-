using System;
using System.Threading;

namespace Tetris
{
  public class Tetris
  {
    int TimeStep = 30;
    string GameOverMsg = "GAME OVER!";
    string GameTitle = "Tetris";
    public void StartGame()
    {
      Console.Title = GameTitle;
      Menu();

      // while (!board.IsGameOver())
      // {
      //   board.CheckUserInput();
      //   board.Update();
      //   board.Draw();
      //   Thread.Sleep(TimeStep);
      // }
    }

    void Menu()
    {
      int val = 0;

      Console.WriteLine("Tetris.");

      while (val != 4)
      {
        Console.WriteLine("1. Play");
        Console.WriteLine("2. High Scores");
        Console.WriteLine("3. About");
        Console.WriteLine("4. Exit");
        val = int.Parse(Console.ReadLine());
        break;
      }

      switch (val)
      {
        case 1:
          Console.Clear();
          Field.Draw(21, 12);
          break;
        case 2:
          Console.WriteLine("Highscores");
          break;
        case 3:
          Console.WriteLine("About");
          break;
        case 4:
          Console.WriteLine("Bye!");
          break;

        default:
          Console.WriteLine("Error");
          break;
      }
    }
  }
}
