using static System.Net.Mime.MediaTypeNames;
using System.Reflection.Emit;
using System.Xml;
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
        Console.Write("\x1b[48;5;220m \x1b[38;5;15;48;5;220m▄▄▄▄\x1b[48;5;220m \x1b[m");
        Console.SetCursorPosition(Input.Cury, Input.Curx+1);
        Console.Write("\x1b[48;5;220m \x1b[48;5;15m \x1b[38;5;15;48;5;38m▄\x1b[48;5;15m \x1b[38;5;15;48;5;38m▄\x1b[48;5;220m \x1b[m");
        Console.SetCursorPosition(Input.Cury, Input.Curx+2);
        Console.Write("\x1b[48;5;220m \x1b[38;5;220;48;5;15m▄\x1b[38;5;220;48;5;0m▄▄▄\x1b[48;5;220m \x1b[m");
    }
    public void LevelUp()
    {
        if (xp >= 100)
        {
            Console.WriteLine("Level UP");
            MaxHp += 10;
            Level += 1;
            Damage = Damage + 5;
            Speed = Speed + 5;
            Evade = Evade + 2;
            xp -= 100;
        }
        Console.WriteLine("Level =" +Level);
        Console.WriteLine("PV =" +MaxHp);
        Console.WriteLine("Damage =" +Damage);
        Console.WriteLine("Speed =" +Speed);
        Console.WriteLine("Evade =" +Evade);
        return;
    }
    public void Heal(int x) //pour soigner de X hp
    {
        hp += x;
        if (hp > maxHp)
        {
            hp = maxHp;
        }
        Console.WriteLine(hp);
    }

    internal void UseItem(Inventory inventory)
    {
        throw new NotImplementedException();
    }

    public int MaxHp { get => maxHp; set => maxHp = value; }
    public int XP { get => xp; set => xp = value; }

    public string Name { get => name; set => name = value; }
}