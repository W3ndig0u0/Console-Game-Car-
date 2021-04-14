using System;

namespace Tetris
{
  class Program
  {
    static void Main(string[] args)
    {

      Console.OutputEncoding = System.Text.Encoding.Unicode;
      // !För att skriva Emojis
      Playfield();


      Console.ReadKey();
    }

    public static void Player()
    {
      Random randomX = new Random();
      randomX.Next(1, 11);
    }
    static void Playfield()
    {
      //   Player playerpos = new Player();
      //   playerpos.

      // !10 * 20 spelbara rutor
      int xField = 12;
      int yField = 22;


      int[,] playfield = new int[xField, yField];


      // !Rita ruta för ruta 
      for (int y = 0; y < playfield.GetLength(1); y++)
      {
        for (int x = 0; x < playfield.GetLength(0); x++)
        {
          {
            // !Gör alla yttre rutor till 1
            if (x == 0 || y == 0 || x == 11 || y == 21)
            {
              Console.Write("1");
            }
            else if (y == 1 && x == 1)
            {
              Console.Write("2");
            }
            else
            {
              Console.Write("0");
            }
          }
        }
        // !Dela isär för varje x
        Console.WriteLine();
      }
    }

  }
}
