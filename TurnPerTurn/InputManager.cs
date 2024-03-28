
using System.Dynamic;
using System.Numerics;
using System.Drawing;
using System.Security.Cryptography;

public class Input
{
    static int cury = 220;
    static int curx = 2;
    static int fight = 0;
    
    public static int Cury { get => cury; set => cury = value; }
    public static int Curx { get => curx; set => curx = value; }
    public static int Fight { get => fight; set => fight = value; }


    public static void Condition()
    {

        Random rand = new Random();
        string image = @"C:\Users\lsaintomer\Documents\GitHub\TurnPerTurnGame\TurnPerTurn\map.bmp";
        Bitmap map = new Bitmap(image);
        Color red = map.GetPixel(0, 0);
        Color green = map.GetPixel(237, 37);
        CombatPhase combatPhase = new CombatPhase();

        Console.SetCursorPosition(cury, curx);
        for (int i = -1; i < 3; i++)
        {
            for (int j = -1; j < 6; j++)
            {
                if (map.GetPixel(cury + j, (curx + i )* 2) == red)
                {
                    Console.SetCursorPosition(cury + j, curx + i);
                    Console.Write("\x1b[48;5;9m");
                    Console.Write(" ");
                }
                else if (map.GetPixel(cury + j, (curx + i) * 2) == green)
                {
                    Console.SetCursorPosition(cury + j, curx + i);
                    Console.Write("\x1b[48;5;35m");
                    Console.Write(" ");
                    fight = rand.Next(10);
                }
                else
                {
                    Console.SetCursorPosition(cury + j, curx + i);
                    Console.Write("\x1b[48;5;15m");
                    Console.Write(" ");
                }
            }
        }
        if (fight > 1)
        {
            Program._Map = false;
        }
    }

    public static void IsInput()
    {

        ConsoleKeyInfo key;
        bool paused = false;
            key = Console.ReadKey();

            if (key.Key == ConsoleKey.UpArrow)
            {
                if (curx > 1)
                {
                    Condition();
                    curx = curx - 1;
                    Player.drawplayer();
                }

            }
            if (key.Key == ConsoleKey.DownArrow)
            {
                if (curx < 57)
                {
                    Condition();
                    curx = curx + 1;
                    Player.drawplayer();
                }
            }
            if (key.Key == ConsoleKey.LeftArrow)
            {
                if (cury > 1)
                {
                    Condition();
                    cury = cury - 1;
                    Player.drawplayer();
                }

            }
            if (key.Key == ConsoleKey.RightArrow)
            {
                if (cury < 232)
                {
                    Condition();
                    cury = cury + 1;
                    Player.drawplayer();
                }
            }
    }

}
