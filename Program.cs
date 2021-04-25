using System;
using System.Collections.Generic;
using System.Threading;
class Program
{
  static void Main()
  {
    float speed = 100f;
    float acceleration = 0.5f;
    int playfieldWidth = 5;
    int livesCount = 5;
    Object userCar = new Object();
    userCar.x = 2;
    userCar.y = Console.WindowHeight - 1;
    userCar.c = '@';
    userCar.color = ConsoleColor.Yellow;

    Random randomGenerator = new Random();
    List<Object> objects = new List<Object>();
    bool gameOver = false;

    // !GameLoop
    while (!gameOver)
    {
      speed += acceleration;
      if (speed > 400)
      {
        speed = 400;
      }

      bool hitted = false;
      // !Medkit (+ liv)
      int chance = randomGenerator.Next(0, 100);
      if (chance < 20)
      {
        Object newObject = new Object();
        newObject.color = ConsoleColor.Cyan;
        newObject.c = '+';
        newObject.x = randomGenerator.Next(0, playfieldWidth);
        newObject.y = 0;
        objects.Add(newObject);
      }
      else
      {
        // !Bil (fiende)
        Object newCar = new Object();
        newCar.color = ConsoleColor.Green;
        newCar.x = randomGenerator.Next(0, playfieldWidth);
        newCar.y = 0;
        newCar.c = '#';
        objects.Add(newCar);
      }

      // !Kontroller
      while (Console.KeyAvailable)
      {
        ConsoleKeyInfo pressedKey = Console.ReadKey(true);

        if (pressedKey.Key == ConsoleKey.LeftArrow)
        {
          if (userCar.x - 1 >= 0)
          {
            userCar.x = userCar.x - 1;
          }
        }
        else if (pressedKey.Key == ConsoleKey.RightArrow)
        {
          if (userCar.x + 1 < playfieldWidth)
          {
            userCar.x = userCar.x + 1;
          }
        }
      }

      // !New "frame" new "thingy"
      List<Object> newList = new List<Object>();
      for (int i = 0; i < objects.Count; i++)
      {
        Object oldCar = objects[i];
        Object newObject = new Object();
        newObject.x = oldCar.x;
        newObject.y = oldCar.y + 1;
        newObject.c = oldCar.c;
        newObject.color = oldCar.color;

        if (newObject.c == '+' && newObject.y == userCar.y && newObject.x == userCar.x)
        {
          livesCount++;
        }

        if (newObject.c == '#' && newObject.y == userCar.y && newObject.x == userCar.x)
        {
          livesCount--;
          hitted = true;

          if (livesCount <= 0)
          {
            Position.PrintStringOnPosition(8, 10, "GAME OVER!!!", ConsoleColor.Red);
            Position.PrintStringOnPosition(8, 12, "Press [enter] to exit", ConsoleColor.Red);
            Console.ReadLine();
            gameOver = false;
          }
        }

        if (newObject.y < Console.WindowHeight)
        {
          newList.Add(newObject);
        }
      }
      objects = newList;
      Console.Clear();

      if (hitted)
      {
        objects.Clear();
        Position.PrintOnPosition(userCar.x, userCar.y, 'X', ConsoleColor.Red);
      }

      else
      {
        Position.PrintOnPosition(userCar.x, userCar.y, userCar.c, userCar.color);
      }

      foreach (Object stuff in objects)
      {
        Position.PrintOnPosition(stuff.x, stuff.y, stuff.c, stuff.color);
      }

      // !rita text
      Position.PrintStringOnPosition(8, 4, "Lives: " + livesCount, ConsoleColor.White);
      Position.PrintStringOnPosition(8, 5, "Speed: " + speed, ConsoleColor.White);
      Thread.Sleep((int)(600 - speed));
    }
  }
}