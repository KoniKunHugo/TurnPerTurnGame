public class Entity
{
    public int Hp;
    public int Damage;
    public int Speed;
    public int Evade;
    public int level;

    public event Action OnTakeDamage;
    public event Action OnDeath;


    public void TakeDamage(int amount)
    {
        Hp -= amount;
        OnTakeDamage?.Invoke();
        IsDead();
    }

    public void IsDead()
    {
        if (Hp <= 0) //dead
        {
            OnDeath?.Invoke(); //previent toutes les classes concernés
            Speed = 0;
            Damage = 0;
            Evade = 0;
        }
    }
    public void UpdateHit()
    {
        Console.WriteLine("oui");
    }

    public void UpdateDeath()
    {
        Console.WriteLine("dead");
        this.OnTakeDamage -= this.UpdateDeath;
        this.OnDeath -= this.UpdateDeath;
    }
}