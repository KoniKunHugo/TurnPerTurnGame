using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

class CombatPhase
{
    public event Action OnTriggerCombat;
    public event Action OnCombatEnd;

    public void EnterCombatPhase()
    {
        OnTriggerCombat?.Invoke();
        Console.WriteLine();
    }

    public void Combat()
    {
        if (player.Speed > foes.Speed)
        {
            //PLAYER ACT FIRST

            if (foes.Hp == 0 || player.Hp == 0)
            {
                UpdateExitCombat();
            }
            //FOE ACT SECOND

            if (foes.Hp == 0 || player.Hp == 0)
            {
                UpdateExitCombat();
            }
        }
        else
        {
            //FOE ACT FIRST
            player.TakeDamage(50);
            if (foes.Hp == 0 || player.Hp == 0)
            {
                UpdateExitCombat();
            }
            //PLAYER ACT SECOND

            if (foes.Hp == 0 || player.Hp == 0)
            {
                UpdateExitCombat();
            }
        }
    }

    public void ExitCombatPhase()
                {
                    OnCombatEnd?.Invoke();
                    if (player.Hp == 0)
                    {
                        //Kill
                    }
                    else
                    {
                        player.XP += 50;
                    }
                }

    public void UpdateExitCombat()
                {
                    this.OnCombatEnd += UpdateExitCombat;
                    this.OnCombatEnd -= UpdateExitCombat;
                }
        

    public void UpdateEnterCombat() 
                {
                    this.OnTriggerCombat += UpdateEnterCombat;
                    this.OnTriggerCombat -= UpdateEnterCombat;
                }


    private Player player = new Player();
    private Foes foes = new Foes();
    private List<string> CombatSceneList = new List<string>();
}