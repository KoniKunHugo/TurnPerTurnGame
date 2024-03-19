class Player
{

    public 
        Player() 
    {
        string name;
        int level = 1;
        int xp = 0;
        int Damage = 10;
        int Speed = 10;
        int Evade = 5;
    }

    public event Action OnTakeDamage;

    public void TakeDamage(int amount)
    {
        OnTakeDamage?.Invoke();
        int hp = 0;
        if (hp == 0) 
        {
            //Player.OnPlayerDeath += UpdateSlider;
            //Player.OnPlayerDeath -= UpdateSlider;
        }
    }

    public event Action OnPlayerDeath;

    private 
        int PV;
        int Str;

    private void UpdateSlider()
    {

    }
}

