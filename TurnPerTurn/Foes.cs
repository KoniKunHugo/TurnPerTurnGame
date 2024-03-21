using System.Reflection.Emit;
using System.Xml.Linq;

public class Foes : Entity
{
    private int Type;

    public Foes(int type)
    {
        Type = type;
        Level = 1;
        Hp = 20;
        this.SeTByType();
    }

    public void SeTByType()
    {
        if (Type == 0) //Vitesse 
        {
            Speed = 20;
            Evade = 10;
            Damage = 5;
        }
        else if (Type == 1) //Puissance
        {
            Speed = 7;
            Evade = 15;
            Damage = 15;
        }
        else if (Type == 2) //Fourberie
        {
            Speed = 10;
            Evade = 10;
            Damage = 7;
        }
        Console.WriteLine("entity set");
    }
}