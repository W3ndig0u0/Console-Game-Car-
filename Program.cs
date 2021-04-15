using System;


namespace Tetris
{
  class Program
  {
    static void Main(string[] args)
    {

      Tetris game = new Tetris();
      game.StartGame();
      Console.ReadLine();
    }
  }
}