class CombatPhase
{
    public event Action TriggerCombat;


    public void EnterCombatPhase()
    {
        TriggerCombat?.Invoke();
        

    }

    public void DrawCombatScene(List)
    {
        Console.WriteLine(List);
    }

    public void Combat(int PlayerSpeed, int FoeSpeed)
    {
        Player player = new Player();
        if (PlayerSpeed > FoeSpeed)
        {
            //PLAYER ACT FIRST

            //FOE ACT SECOND
        }
        else
        {
            //FOE ACT FIRST
            player.TakeDamage(50);
            //PLAYER ACT SECOND
        }
    }

    public void ExitCombatPhase() 
    {
        
    }

    private

        List<string> CombatSceneList = new List<string>();
}