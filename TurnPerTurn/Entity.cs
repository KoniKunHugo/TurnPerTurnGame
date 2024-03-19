public class Entity
{
    public int Hp;
    public int Damage;
    public int Speed;
    public int Evade;

    public event Action OnTakeDamage;
    public event Action OnDeath;


    public void TakeDamage(int amount)
    {
        Hp -= amount;
        OnTakeDamage.Invoke();
    }

    public bool IsDead()
    {
        if (Hp <= 0) //dead
        {
            OnDeath?.Invoke(); //previent toutes les classes concernés
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
    public void UpadateSlider()
    {
        Console.WriteLine("oui");
    }
}