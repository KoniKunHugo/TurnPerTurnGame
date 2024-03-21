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

