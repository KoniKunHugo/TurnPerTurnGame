public class Entity
{
    private int hp;
    private int damage;
    private int speed;
    private int evade;
    private int level;

    

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
        OnTakeDamage.Invoke();
        IsDead();
    }

    public void IsDead()
    {
        if (hp <= 0) //dead
        {
            OnDeath?.Invoke(); //previent toutes les classes concernés
            speed = 0;
            damage = 0;
            evade = 0;
        } 
    }
    public void UpadateHit()
    {
        Console.WriteLine("oui");
    }

    public void UpadateDeath()
    {
        this.OnTakeDamage -= this.UpadateDeath;
        this.OnDeath -= this.UpadateDeath;
    }
}