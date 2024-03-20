using System.Xml.XPath;

class Player : Entity
{
    public int XP;
    public int Level;
    public string Name;


    public void LevelUp()
    {
        if (XP == 100)
        {
            Level += 1;
            Damage = Damage + 5;
            Speed = Speed + 5;
            Evade = Evade + 2;
        }
    }

    private void Temp()
    {

    }
}

