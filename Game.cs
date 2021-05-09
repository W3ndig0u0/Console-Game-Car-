using System;
using System.Collections.Generic;
using System.Threading;
public class Game
{
  public static void GameMethod()
  {
    float speed = 100f;
    int livesCount = 2;

    float acceleration = 0.5f;
    int playfieldWidth = 5;

    Object userCar = new Object();
    Random randomGenerator = new Random();
    // !Ska lägga in saker senare
    List<Object> objects = new List<Object>();
    bool gameOver = false;

    userCar.x = 2;
    userCar.y = Console.WindowHeight - 1;
    userCar.character = '@';
    userCar.color = ConsoleColor.Yellow;

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

      if (chance < 25)
      {
        newMedkit();
      }

      else
      {
        // !fiende (- liv)
        newEnemy();
      }

      // !Kontroller
      while (Console.KeyAvailable)
      {
        Controlls();
      }

      List<Object> newList = new List<Object>();
      for (int i = 0; i < objects.Count; i++)
      {
        // !ny "frame", ner ett 1 y
        Object oldCar = objects[i];
        Object newObject = new Object();
        newObject.x = oldCar.x;
        newObject.y = oldCar.y + 1;
        newObject.character = oldCar.character;
        newObject.color = oldCar.color;

        // !Vad som händer när spelaren träffar medkit
        if (newObject.character == '+' && newObject.y == userCar.y && newObject.x == userCar.x)
        {
          livesCount++;
        }

        // !Vad som händer när spelaren träffar fienden
        if (newObject.character == '#' && newObject.y == userCar.y && newObject.x == userCar.x)
        {
          livesCount--;
          hitted = true;

          // !När liv blir 0
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

      // !Spelet kollar om man är träffad eller inte
      if (hitted)
      {
        objects.Clear();
        Position.PrintOnPosition(userCar.x, userCar.y, 'X', ConsoleColor.Red);
      }

      else
      {
        Position.PrintOnPosition(userCar.x, userCar.y, userCar.character, userCar.color);
      }

      foreach (Object stuff in objects)
      {
        Position.PrintOnPosition(stuff.x, stuff.y, stuff.character, stuff.color);
      }
      draw();
    }

    void newMedkit()
    {
      // !Vad En medkit består av 
      Object newObject = new Object();
      newObject.color = ConsoleColor.Cyan;
      newObject.character = '+';
      newObject.x = randomGenerator.Next(0, playfieldWidth);
      newObject.y = 0;
      objects.Add(newObject);
    }

    void newEnemy()
    {
      // !Vad En fiende består av 
      Object newCar = new Object();
      newCar.color = ConsoleColor.Green;
      newCar.x = randomGenerator.Next(0, playfieldWidth);
      newCar.y = 0;
      newCar.character = '#';
      objects.Add(newCar);
    }

    void Controlls()
    {
      ConsoleKeyInfo pressedKey = Console.ReadKey(true);

      // !Om spelaren trycker vänster/höger knapp rör sig spelaren
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

    void draw()
    {
      // !rita text
      Position.PrintStringOnPosition(9, 4, "Lives: " + livesCount, ConsoleColor.White);
      Position.PrintStringOnPosition(9, 5, "Speed: " + speed, ConsoleColor.White);
      Position.PrintStringOnPosition(9, 7, "You Are", ConsoleColor.DarkCyan);
      Position.PrintStringOnPosition(17, 7, "@", ConsoleColor.Yellow);
      Position.PrintStringOnPosition(9, 8, "Press <- TO go Left ", ConsoleColor.Green);
      Position.PrintStringOnPosition(9, 9, "Press -> TO go Right ", ConsoleColor.Green);
      Position.PrintStringOnPosition(8, 11, "#", ConsoleColor.Magenta);
      Position.PrintStringOnPosition(10, 11, "Will Hurt You!! Avoid Them!!! ", ConsoleColor.DarkBlue);
      Position.PrintStringOnPosition(8, 12, "+", ConsoleColor.Magenta);
      Position.PrintStringOnPosition(10, 12, "Are Good, They will give you a Life", ConsoleColor.DarkBlue);
      // !Hur snabbt det går per "frame" (internet)
      Thread.Sleep((int)(600 - speed));
    }
  }
}