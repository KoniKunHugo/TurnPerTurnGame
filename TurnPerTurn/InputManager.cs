using System.Dynamic;
using System.Numerics;

public class Input
{
    static int cury = 2;
    static int curx = 2;

    public static int Cury { get { return cury; } }
    public static int Curx { get { return curx; } }




    public static void IsInput()
    {
        ConsoleKeyInfo key;
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
                    for (int i = curx - 1; i <= curx + 3; i++)
                    {
                        for (int j = cury - 1; j <= cury + 7; j++)
                        {
                            Console.Write(Map._map[i, j]);
                            Console.SetCursorPosition(j + 1, i);
                        }
                    }
                    curx = curx - 1;
                    Player.drawplayer();
                }

            }
            if (key.Key == ConsoleKey.DownArrow)
            {
                if (curx < 27)
                {
                    /*Console.SetCursorPosition(cury, curx);
                    Console.Write("      ");
                    Console.SetCursorPosition(cury, curx + 1);
                    Console.Write("       ");
                    Console.SetCursorPosition(cury, curx + 2);
                    Console.Write("       ");*/
                    Console.SetCursorPosition(cury, curx);
                    for (int i = curx - 1; i <= curx + 3; i++)
                    {
                        for (int j = cury - 1; j <= cury + 8; j++)
                        {
                            Console.Write(Map._map[i, j]);
                            Console.SetCursorPosition(j + 1, i);
                        }
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
                    for (int i = curx; i <= curx + 3; i++)
                    {
                        for (int j = cury + 1; j <= cury + 6; j++)
                        {
                            Console.Write(Map._map[i, j]);
                            Console.SetCursorPosition(j, i);
                        }
                    }
                    cury = cury - 1;
                    Player.drawplayer();
                }

            }
            if (key.Key == ConsoleKey.RightArrow)
            {
                if (cury < 113)
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
                    for (int i = curx; i <= curx + 3; i++)
                    {
                        for (int j = cury - 1; j <= cury + 5; j++)
                        {
                            Console.Write(Map._map[i, j]);
                            Console.SetCursorPosition(j + 1, i);
                        }
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
