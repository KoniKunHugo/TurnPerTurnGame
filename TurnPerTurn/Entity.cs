public class Entity
{
    public int Hp;
    public int Damage;
    public int Speed;
    public int Evade;

    public void TakeDamage(int amount)
    {
        Hp -= amount;
    }

    public bool IsDead()
    {
        if (Hp <= 0) //dead
        {
            Speed = 0;
            Damage = 0;
            Evade = 0;
            return true;
        }
        else 
        {
            return false;
        } 
    }
}