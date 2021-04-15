using System;
using System.Threading;

namespace Tetris
{

  public class Field
  {
    public static void Draw(int ysize, int xsize)
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