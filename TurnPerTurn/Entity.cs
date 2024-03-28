public class Entity
{

    protected int hp;
    protected int damage;
    protected int speed;
    protected int evade;
    protected int level;

    public int Hp { get => hp; set => hp = value; }
    public int Damage { get => damage; set => damage = value; }
    public int Speed { get => speed; set => speed = value; }
    public int Evade { get => evade; set => evade = value; }
    public int Level { get => level; set => level = value; }

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
        if (hp <= 0) //dead
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