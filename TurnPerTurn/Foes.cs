using System.Reflection.Emit;
using System.Xml.Linq;

public class Foes : Entity
{

    private Random rand = new Random();
    private int style;

    public void Entity(int style)
    {
        Style = style;

        Level = 1;
        Hp = 30;
        if (Style == 0) //Vitesse 
        {
            Speed = 20;
            Evade = 10;
            Damage = 5;
        }
        else if (Style == 1) //Puissance
        {
            Speed = 7;
            Evade = 15;
            Damage = 15;
        }
        else if (Style == 2) //Fourberie
        {
            Speed = 10;
            Evade = 10;
            Damage = 7;
        }
        return;
    }

    public int Style { get => style; set => style = value; }

    public void randomFoe()
    {
        int Temp;
        Temp = rand.Next(3);
        Entity(Temp);
    }
}