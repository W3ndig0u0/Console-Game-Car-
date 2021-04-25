using System;
class Position
{
  // !Rita sakerna
  public static void PrintOnPosition(int x, int y, char c, ConsoleColor color)
  {
    Console.SetCursorPosition(x, y);
    Console.ForegroundColor = color;
    Console.Write(c);
  }
  // !Rita texten
  public static void PrintStringOnPosition(int x, int y, string str, ConsoleColor color)
  {
    Console.SetCursorPosition(x, y);
    Console.ForegroundColor = color;
    Console.Write(str);
  }
}