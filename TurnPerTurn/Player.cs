using static System.Net.Mime.MediaTypeNames;
using System.Reflection.Emit;
using System.Xml;

class Player : Entity
{
    public
        Player(string _name)
    {
        name = _name;
        level = 1;
        xp = 0;
        Damage = 10;
        Speed = 10;
        Evade = 5;
        Hp = 20;
    }

    protected
    string name;
    int xp;

    public static void drawplayer()
    {
        /*Console.SetCursorPosition(Input.Cury, Input.Curx);
        Console.Write("P");*/
        /*Console.SetCursorPosition(Input.Cury, Input.Curx);
        Console.Write("(\\__/) ");
        Console.SetCursorPosition(Input.Cury, Input.Curx + 1);
        Console.Write("(+'.'+)");
        Console.SetCursorPosition(Input.Cury, Input.Curx + 2);
        Console.Write("(*)_(*)");*/
        /*string player = File.ReadAllText(@"C:\Users\lsaintomer\Documents\GitHub\TurnPerTurnGame\TurnPerTurn\player.txt").Replace("\\x1b", "\x1b");
        Console.WriteLine(player);*/
        
        Console.SetCursorPosition(Input.Cury, Input.Curx);
        Console.Write("\x1b[48;5;220m \x1b[38;5;15;48;5;220m▄▄▄▄\x1b[48;5;220m \x1b[m");
        Console.SetCursorPosition(Input.Cury, Input.Curx+1);
        Console.Write("\x1b[48;5;220m \x1b[48;5;15m \x1b[38;5;15;48;5;38m▄\x1b[48;5;15m \x1b[38;5;15;48;5;38m▄\x1b[48;5;220m \x1b[m");
        Console.SetCursorPosition(Input.Cury, Input.Curx+2);
        Console.Write("\x1b[48;5;220m \x1b[38;5;220;48;5;15m▄\x1b[38;5;220;48;5;0m▄▄▄\x1b[48;5;220m \x1b[m");
    }
}
/*
(\__/)    \\_//   \\_//  (\__/)   (\ /)   l\_/l
(+'.'+)   (o.o)   (0.0)  (O_O )  ( '.' )  (*_*)   
(*)_(*)   (><)    (><)   (w w )   (u u)   (w w)

\x1b[48;5;220m \x1b[38;5;15;48;5;220m▄▄▄▄\x1b[48;5;220m \x1b[m
\x1b[48;5;220m \x1b[48;5;15m \x1b[38;5;15;48;5;38m▄\x1b[48;5;15m \x1b[38;5;15;48;5;38m▄\x1b[48;5;220m \x1b[m
\x1b[48;5;220m \x1b[38;5;220;48;5;15m▄\x1b[38;5;220;48;5;0m▄▄▄\x1b[48;5;220m \x1b[m
 */