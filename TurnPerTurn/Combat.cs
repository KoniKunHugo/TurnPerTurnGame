using System.Collections.Generic;
using System.ComponentModel.Design;
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
            Console.WriteLine("Show them Your Moves");
            Console.WriteLine("-" + player.SpellOne);
            Console.WriteLine("-" + player.SpellTwo);
            Console.WriteLine("-" + player.SpellThree);
            Console.WriteLine("-" + player.SpellFour);
            string Temp = Console.ReadLine();
            if (player.SpellOne == Temp || player.SpellTwo == Temp || player.SpellThree == Temp || player.SpellFour == Temp)
            {
                CheckAbility(Temp);
            }

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

    public void CheckAbility(string Temp)
    {
        string Ability = Temp;
        if (Ability == player.SpellOne)
        {
            //if (foes.Type == 0) 
            //{
            //    foes.Hp -= (30*1.5) ; 
            //}
            //else
            //{
            foes.Hp -= 30;
            //}
        }
        if (Ability == player.SpellTwo)
        {
            //if (foes.Type == 2) 
            //{
            //    foes.Hp -= (30*1.5) ; 
            //}
            //else
            //{
            foes.Hp -= 30;
            //}
        }
        if (Ability == player.SpellThree)
        {
            //if (foes.Type == 1) 
            //{
            //    foes.Hp -= (30*1.5) ; 
            //}
            //else
            //{
                foes.Hp -= 30;
            //}
        }
        if (Ability == player.SpellFour)
        {
            player.Damage = player.Damage * 2;
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
                        player.LevelUp();
                    }
                }

    public void UpdateExitCombat()
                {
                    OnCombatEnd += UpdateExitCombat;
                    OnCombatEnd -= UpdateExitCombat;
                }
        

    public void UpdateEnterCombat() 
                {
                    OnTriggerCombat += UpdateEnterCombat;
                    OnTriggerCombat -= UpdateEnterCombat;
                }

    
    private Player player = new Player();
    private Foes foes = new Foes();
    private List<string> CombatSceneList = new List<string>();
}