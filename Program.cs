using System;
using System.Threading;
using System.Diagnostics;


namespace Tetris
{
  class Program
  {

    static int maxTime = 25;
    static int timer = 0;
    static void Main(string[] args)
    {
      Console.Title = "Tetris | By: Jing Xiang Xu";
      menu();

      Console.ReadLine();
    }


    static void menu()
    {
      int val = 0;

      Console.WriteLine("Tetris.");

      Console.Write("Ange ditt namn: ");
      string name = Console.ReadLine();

      Console.WriteLine("\nHejsan " + name + "! Välkommen Till Menyn!");

      while (val != 4)
      {
        Console.WriteLine("\nVälj ett av alternativen.");
        Console.WriteLine("1. Play");
        Console.WriteLine("2. High Scores");
        Console.WriteLine("3. About");
        Console.WriteLine("4. Exit");
        Console.Write("Jag väljer alternativ : ");
        val = int.Parse(Console.ReadLine());
        break;
      }

      switch (val)
      {
        case 1:
          Console.Clear();
          Console.WriteLine("Spelet startar");
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
      int currentPosX = 6;
      int currentPosY = 0;

      int[,] block = new int[currentPosY, currentPosX];
      int[,] playfield = new int[ysize, xsize];

      // !Rita ruta för ruta 
      for (int y = 0; y < playfield.GetLength(0); y++)
      {
        for (int x = 0; x < playfield.GetLength(1); x++)
        {
          {
            // !Gör alla yttre rutor till nåt annat
            if (x == 0 || x == 11 || y == 20)
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
      for (int i = 0; i < playfield.GetLength(0); i++)
      {
        if (i == currentPosY)
        {
          Thread.Sleep(100);
          Console.Write("@");
          currentPosY += 1;
        }
      }
    }

    // static void InputHandler()
    // {
    //   switch (ConsoleKey)
    //   {
    //     case ConsoleKey.LeftArrow:
    //       // !Left arrow = move left (if it doesn't collide)
    //       break;

    //     case ConsoleKey.RightArrow:
    //       // !Right arrow = move right (if it doesn't collide)
    //       break;

    //     case ConsoleKey.Z:
    //       //! Rotate block (if it doesn't collide)

    //       break;

    //     case ConsoleKey.X:
    //       //! Rotate block (if it doesn't collide)

    //       break;

    //     case ConsoleKey.Spacebar:
    //       //!hard drop
    //       break;
    //   }
    // }


  }
}