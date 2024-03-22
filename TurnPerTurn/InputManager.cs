using System.Dynamic;
using System.Numerics;
using System.Drawing;

public class Input
{
    static int cury = 2;
    static int curx = 2;

    public static int Cury { get { return cury; } }
    public static int Curx { get { return curx; } }




    public static void IsInput()
    {
        string image = @"C:\Users\lsaintomer\Documents\GitHub\TurnPerTurnGame\TurnPerTurn\map.bmp";
        Bitmap map = new Bitmap(image);
        ConsoleKeyInfo key;
        Color red = map.GetPixel(0,0);
        Color white = map.GetPixel(0,16);
        do
        {
            key = Console.ReadKey();
            if (key.Key == ConsoleKey.UpArrow)
            {
                if (curx > 1)
                {
                    /*Console.SetCursorPosition(cury, curx);
                    Console.Write(" ");
                    curx = curx - 1;
                    Console.SetCursorPosition(cury, curx);
                    Console.Write("P");*/
                    /*Console.Write(Map._map[cury,curx]);
                    Console.Write("      ");
                    Console.SetCursorPosition(cury, curx + 1);
                    Console.Write("       ");
                    Console.SetCursorPosition(cury, curx + 2);
                    Console.Write("       ");*/
                    Console.SetCursorPosition(cury, curx);
                    
                    if (map.GetPixel(cury, curx) == red)
                    {
                        Console.Write("\x1b[48;5;9m");
                        Console.Write(" ");
                    }
                    else
                    {
                        Console.Write("\x1b[48;5;15m");
                        Console.Write(" ");
                    }
                    
                    curx = curx - 1;
                    Player.drawplayer();
                }

            }
            if (key.Key == ConsoleKey.DownArrow)
            {
                if (curx < 57)
                {
                    /*Console.SetCursorPosition(cury, curx);
                    Console.Write("      ");
                    Console.SetCursorPosition(cury, curx + 1);
                    Console.Write("       ");
                    Console.SetCursorPosition(cury, curx + 2);
                    Console.Write("       ");*/
                    Console.SetCursorPosition(cury, curx);

                    if (map.GetPixel(cury, curx) == red)
                    {
                        Console.Write("\x1b[48;5;9m");
                        Console.Write(" ");
                    }
                    else
                    {
                        Console.Write("\x1b[48;5;15m");
                        Console.Write(" ");
                    }

                    curx = curx + 1;
                    Player.drawplayer();
                }
            }
            if (key.Key == ConsoleKey.LeftArrow)
            {
                if (cury > 1)
                {
                    /*Console.SetCursorPosition(cury-1, curx);
                    Console.Write("P ");
                    cury = cury - 1;*/
                    /*Console.SetCursorPosition(cury, curx);
                    Console.Write("      ");
                    Console.SetCursorPosition(cury, curx + 1);
                    Console.Write("       ");
                    Console.SetCursorPosition(cury, curx + 2);
                    Console.Write("       ");*/
                    Console.SetCursorPosition(cury, curx);

                    if (map.GetPixel(cury, curx) == red)
                    {
                        Console.Write("\x1b[48;5;9m");
                        Console.Write(" ");
                    }
                    else
                    {
                        Console.Write("\x1b[48;5;15m");
                        Console.Write(" ");
                    }
                    cury = cury - 1;
                    Player.drawplayer();
                }

            }
            if (key.Key == ConsoleKey.RightArrow)
            {
                if (cury < 233)
                {
                    /*Console.SetCursorPosition(cury, curx);
                    Console.Write(" P");
                    cury = cury + 1;*/
                    /*Console.SetCursorPosition(cury, curx);
                    Console.Write("      ");
                    Console.SetCursorPosition(cury, curx + 1);
                    Console.Write("       ");
                    Console.SetCursorPosition(cury, curx + 2);
                    Console.Write("       ");*/
                    Console.SetCursorPosition(cury, curx);

                    if (map.GetPixel(cury, curx) == red)
                    {
                        Console.Write("\x1b[48;5;9m");
                        Console.Write(" ");
                    }
                    else
                    {
                        Console.Write("\x1b[48;5;15m");
                        Console.Write(" ");
                    }
                    cury = cury + 1;
                    Player.drawplayer();
                }
            }
        } while (key.Key != ConsoleKey.Escape);
        /*public int Cury { get => _cury; }
        public int Curx { get => _curx; }*/
    }

}
