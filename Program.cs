using System;
using System.Threading;
using System.Diagnostics;


namespace Tetris
{
  class Program
  {
    static void Main(string[] args)
    {
      menu();

      Console.ReadLine();
    }

    static void menu()
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
          Draw(21, 12);
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

    static void Draw(int ysize, int xsize)
    {
      int currentPosX = 5;
      int currentPosY = 1;

      int[,] block = new int[currentPosY, currentPosX];
      int[,] playfield = new int[ysize, xsize];

      // !Rita ruta för ruta 
      for (int y = 0; y < playfield.GetLength(0); y++)
      {
        for (int x = 0; x < playfield.GetLength(1); x++)
        {
          {
            Thread.Sleep(20);
            if (x == currentPosX && y == currentPosY)
            {
              Console.Write("@");
              currentPosY++;
            }

            // !Gör alla yttre rutor till nåt annat
            if (x == 0 || x == xsize - 1 || y == ysize - 1)
            {
              Console.Write("=");
            }
            else
            {
              Console.Write(" ");
            }
          }
        }
        // !Dela isär för varje rad
        Console.WriteLine();
      }
    }

  }
}