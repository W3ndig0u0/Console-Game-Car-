using System;

namespace Tetris
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.Title = "Tetris | By: Jing Xiang Xu";
      field(21, 12);


      Console.ReadKey();
    }

    static void field(int ysize, int xsize)
    {

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
    }

  }
}
