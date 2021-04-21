using System;
class Position
{
  public static void PrintOnPosition(int x, int y, char c, ConsoleColor color = ConsoleColor.Gray)
  {
    Console.SetCursorPosition(x, y);
    Console.ForegroundColor = color;
    Console.Write(c);
  }
  public static void PrintStringOnPosition(int x, int y, string str, ConsoleColor color = ConsoleColor.Gray)
  {
    Console.SetCursorPosition(x, y);
    Console.ForegroundColor = color;
    Console.Write(str);
  }
}