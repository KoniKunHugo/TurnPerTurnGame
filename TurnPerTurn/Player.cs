using System.Security.Cryptography;

public class Player : Entity
{
    public string SpellOne = "KneeBreaker";
    public string SpellTwo = "Uppercut";
    public string SpellThree = "Flurrie Blows";
    public string SpellFour = "Bulk Up";

    private int maxHp;
    private string name;
    private int xp;

    private List<String> attacks;
    public List<String> Attacks { get => attacks; set => attacks = value; }
    private List<Player> allies;
    public List<Player> Allies { get => allies; set => allies = value; }
    
    public
        Player(string _name)
    {
        name = _name;
        level = 1;
        xp = 75;
        Damage = 10;
        Speed = 10;
        Evade = 5;
        Hp = 20;
        maxHp = Hp;
        allies = new List<Player> { };
        allies.Add(this);
        attacks = new List<string> { };
        attacks.Add(SpellOne);
        attacks.Add(SpellTwo);
        attacks.Add(SpellThree);
        attacks.Add(SpellFour);
    }

    public static void drawplayer()
    {
        Console.SetCursorPosition(Input.Cury, Input.Curx);
        Console.Write("(\\__/)");
        Console.SetCursorPosition(Input.Cury, Input.Curx + 1);
        Console.Write("(+'.'+)");
        Console.SetCursorPosition(Input.Cury, Input.Curx + 2);
        Console.Write("(*)_(*)");

    }
    public void LevelUp()
    {
        if (xp >= 100)
        {
            MaxHp += 10;
            Level += 1;
            Damage = Damage + 5;
            Speed = Speed + 5;
            Evade = Evade + 2;
            xp -= 100;
        }
        Console.WriteLine(Level);
        Console.WriteLine(MaxHp);
        Console.WriteLine(Damage);
        Console.WriteLine(Speed);
        Console.WriteLine(Evade);
        return;
    }
    public void Heal(int x) //pour soigner de X hp
    {
        this.hp += x;
        if (hp > maxHp)
        {
            hp = maxHp;
        }
    }

    internal void UseItem(Inventory inventory)
    {
        throw new NotImplementedException();
    }

    public int MaxHp { get => maxHp; set => maxHp = value; }
    public int XP { get => xp; set => xp = value; }

    public string Name { get => name; set => name = value; }
}

/*
(\__/)    \\_//   \\_//  (\__/)   (\ /)   l\_/l
(+'.'+)   (o.o)   (0.0)  (O_O )  ( '.' )  (*_*)   
(*)_(*)   (><)    (><)   (w w )   (u u)   (w w)
 */
