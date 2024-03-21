using System.Security.Cryptography;

class Player : Entity
{
    private string name;
    private int xp;
    public string Name { get => name; }
    public int Xp { get => xp; set => xp = value; }

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
        allies = new List<Player> {  };
        allies.Add(this);
    }
}