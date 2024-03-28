using System;
using System.Security.Cryptography.X509Certificates;
using System.Drawing;
using static System.Net.Mime.MediaTypeNames;
using System.Reflection.Emit;
using System.IO;

public static class Map
{
   
    public static void MapColor()
    {
        string map = File.ReadAllText(@"C:\Users\lsaintomer\Documents\GitHub\TurnPerTurnGame\TurnPerTurn\map.txt").Replace("\\x1b", "\x1b");
        Console.WriteLine(map);
        Console.SetCursorPosition(0, 0);
        Player.drawplayer();
    }

    public static void GameOver()
    {
        string map = File.ReadAllText(@"C:\Users\lsaintomer\Documents\GitHub\TurnPerTurnGame\TurnPerTurn\GameOver.txt").Replace("\\x1b", "\x1b");
        Console.WriteLine(map);
        Console.SetCursorPosition(0, 0);
    }
}