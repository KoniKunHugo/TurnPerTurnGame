public class Foes : Entity
{
    private Random rand = new Random();
    private int style;

    public void Entity(int style)
    {
        Style = style;

        Hp = 50;
        if (Style == 0) //Vitesse 
        {
            Style = 0;
            Speed = 20;
            Evade = 5;
        }
        else if (Style == 1) //Puissance
        {
            Style = 1;
            Speed = 5;
            Evade = 20;
        }
        else if (Style == 2) //Fourberie
        {
            Style = 2;
            Speed = 10;
            Evade = 10;
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