public class Foes : Entity
{
    private Random rand = new Random();
    int Type;

    public void Entity(int type)
    {
        Type = type;

        Hp = 50;
        if (Type == 0) //Vitesse 
        {
            Speed = 20;
            Evade = 5;
        }
        else if ( Type == 1) //Puissance
        {
            Speed = 5;
            Evade = 20;
        }
        else if (Type == 2) //Fourberie
        {
            
            Speed = 10;
            Evade = 10;
        }
        return;
    }

    public void randomFoe()
    {
        int Temp;
        Temp = rand.Next(3);
        Entity(Temp);
    }
}