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
        Console.SetCursorPosition(Input.Cury, Input.Curx);
        Console.Write("(\\__/)");
        Console.SetCursorPosition(Input.Cury, Input.Curx + 1);
        Console.Write("(+'.'+)");
        Console.SetCursorPosition(Input.Cury, Input.Curx + 2);
        Console.Write("(*)_(*)");

    }
}
/*
(\__/)    \\_//   \\_//  (\__/)   (\ /)   l\_/l
(+'.'+)   (o.o)   (0.0)  (O_O )  ( '.' )  (*_*)   
(*)_(*)   (><)    (><)   (w w )   (u u)   (w w)
 */