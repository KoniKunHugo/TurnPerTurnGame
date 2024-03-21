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
=======
using System.Net;
using System.Xml.XPath;

class Player : Entity
{
    //public Player()
    //{
    //    int maxHp;
    //    int xp;
    //    int level;
    //    string name;
    //}

    public int maxHp;
    public int xp;
    public int level;
    public string name;



    public void LevelUp()
    {
        if (XP == 100)
        {
            MaxHp += 10;
            Level += 1;
            Damage = Damage + 5;
            Speed = Speed + 5;
            Evade = Evade + 2;
            XP -= 100;
        }
        return;
    }

    public string SpellOne = "KneeBreaker";
    public string SpellTwo = "Uppercut";
    public string SpellThree = "Flurrie Blows"; 
    public string SpellFour = "Bulk Up";

    public int MaxHp { get => maxHp; set => maxHp = value; }
    public int XP { get => xp; set => xp = value ; }
    public int Level { get => level; set => level = value; }
    public string Name { get => name; set => name = value; }
}

