using System.Numerics;
using System.Reflection.Emit;
using System.Xml.Linq;


public class Foes : Entity
{

    private Random rand = new Random();
    private int style;
    int ai_level;

    public void Entity(int style)
    {
        Style = style;
        string _name;

        Level = 1;
        Hp = 30;
        if (Style == 0) //Vitesse 
        {
            _name = "Prot.SPX-190";
            Speed = 20;
            Evade = 10;
            Damage = 5;
        }
        else if (Style == 1) //Puissance
        {
            _name = "Prot.PWR-330";
            Speed = 7;
            Evade = 15;
            Damage = 15;
        }
        else if (Style == 2) //Fourberie
        {
            _name = "Prot.STLR-850";
            Speed = 10;
            Evade = 10;
            Damage = 7;
        }
        return;
    }

    public int Style { get => style; set => style = value; }
    public int AI_Level { get => ai_level; set => ai_level = value; }

    public void randomFoe()
    {
        int Temp;
        Temp = rand.Next(3);
        Entity(Temp);
    }
}