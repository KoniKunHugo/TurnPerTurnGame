using System.Security.Cryptography;

class Player : Entity
{
    private string name;
    private int xp;
    public string Name { get => name; }
    public int Xp { get => xp; set => xp = value; }

    public string SpellOne = "KneeBreaker";
    public string SpellTwo = "Uppercut";
    public string SpellThree = "Flurrie Blows";
    public string SpellFour = "Bulk Up";

    private List<String> attacks;

    public List<String> Attacks { get => attacks; set => attacks = value; }

    private List<Player> allies;
    public List<Player> Allies { get => allies; set => allies = value; }
    
    public
        Player(string _name)
    {
        name = _name;
        Level = 1;
        xp = 0;
        Damage = 10;
        Speed = 10;
        Evade = 5;
        Hp = 20;
        allies = new List<Player> { };
        allies.Add(this);
        attacks = new List<string> { };
        attacks.Add(SpellOne);
        attacks.Add(SpellTwo);
        attacks.Add(SpellThree);
        attacks.Add(SpellFour);
    }
}