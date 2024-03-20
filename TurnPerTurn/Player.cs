using System.Security.Cryptography;

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

    private string name;
    int xp;

    public string Name { get => name; }
}