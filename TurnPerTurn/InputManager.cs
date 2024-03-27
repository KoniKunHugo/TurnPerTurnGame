using System.Dynamic;
using System.Numerics;
using System.Drawing;

public class Input
{
    static int cury = 2;
    static int curx = 2;

    public static int Cury { get { return cury; } }
    public static int Curx { get { return curx; } }

    public static void Condition()
    {
        string image = @"C:\Users\lsaintomer\Documents\GitHub\TurnPerTurnGame\TurnPerTurn\map.bmp";
        Bitmap map = new Bitmap(image);
        Color red = map.GetPixel(0, 0);
        Color white = map.GetPixel(50, 18);
        Color green = map.GetPixel(237, 37);

        Console.SetCursorPosition(cury, curx);

        if (map.GetPixel(cury, curx*2) == red)
        {
            Console.Write("\x1b[48;5;9m      ");
            for (int i = 0;i < 3; i++)
            {
                Console.SetCursorPosition(cury, curx + i);
                Console.Write("\x1b[48;5;9m");
                Console.Write(" ");
            }
        }
        else if (map.GetPixel(cury,curx*2) == green)
        {
            Console.Write("\x1b[48;5;35m      ");
            for (int i = 0; i < 3; i++)
            {
                Console.SetCursorPosition(cury, curx + i);
                Console.Write("\x1b[48;5;35m");
                Console.Write(" ");
            }
        }
        else 
        {
            Console.Write("\x1b[48;5;15m      ");
            for (int i = 0; i < 3; i++)
            {
                Console.SetCursorPosition(cury, curx + i);
                Console.Write("\x1b[48;5;15m");
                Console.Write(" ");
            }
        }
    }

    public static void IsInput()
    {

        ConsoleKeyInfo key;
        do
        {
            key = Console.ReadKey();
            if (key.Key == ConsoleKey.UpArrow)
            {
                if (curx > 0)
                {
                    Condition();
                    curx = curx - 1;
                    Player.drawplayer();
                }

            }
            if (key.Key == ConsoleKey.DownArrow)
            {
                if (curx < 60)
                {
                    Condition();

                    curx = curx + 1;
                    Player.drawplayer();
                }
            }
            if (key.Key == ConsoleKey.LeftArrow)
            {
                if (cury > 0)
                {
                    Condition();
                    cury = cury - 1;
                    Player.drawplayer();
                }

            }
            if (key.Key == ConsoleKey.RightArrow)
            {
                if (cury < 237)
                {
                    Condition();
                    cury = cury + 1;
                    Player.drawplayer();
                }
            }
        } while (key.Key != ConsoleKey.Escape);
        /*public int Cury { get => _cury; }
        public int Curx { get => _curx; }*/
    }

}

