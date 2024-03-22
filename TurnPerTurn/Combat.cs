using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Security.Cryptography.X509Certificates;

class CombatPhase
{
    public event Action OnCombatEnd;


    public void EnterPredeterminedCombatPhase()
    {
        //We'll choose manually
        DrawCombatPhase();
        Combat();
    }

    public void EnterWildCombatPhase()
    {
        foes.randomFoe();
        DrawCombatPhase();
        Combat();
    }

    public void DrawCombatPhase() 
    {
        Console.WriteLine("------------------");
    }
    public void Combat()
    {
        while (true) {
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
                    Console.WriteLine("Attaque");
                    CheckAbility(Temp);
                    Console.WriteLine(foes.Hp + "Mob");
                    Console.WriteLine(player.Hp + "Player");
                }

                if (foes.Hp <= 0 || player.Hp <= 0)
                {
                    UpdateExitCombat();
                    break;
                }
                //FOE ACT SECOND
                
                if (foes.Hp <= 0 || player.Hp <= 0)
                {
                    UpdateExitCombat();
                    break;
                }
            }
            else
            {
                //FOE ACT FIRST
                player.TakeDamage(1);
                if (foes.Hp <= 0 || player.Hp <= 0)
                {
                    UpdateExitCombat();
                    break;

                }
                Console.WriteLine(player.Hp + "Player");
                //PLAYER ACT SECOND
                Console.WriteLine("Show them Your Moves");
                Console.WriteLine("-" + player.SpellOne);
                Console.WriteLine("-" + player.SpellTwo);
                Console.WriteLine("-" + player.SpellThree);
                Console.WriteLine("-" + player.SpellFour);
                string Temp = Console.ReadLine();
                if (player.SpellOne == Temp || player.SpellTwo == Temp || player.SpellThree == Temp || player.SpellFour == Temp)
                {
                    Console.WriteLine("Attaque");
                    CheckAbility(Temp);
                    Console.WriteLine(foes.Hp + "Mob");
                    Console.WriteLine(player.Hp + "Player");
                }
                if (foes.Hp <= 0 || player.Hp <= 0)
                {
                    UpdateExitCombat();
                    break;
                }
            }
        }
    }

    public void CheckAbility(string Temp)
    {
        string Ability = Temp;
        if (Ability == player.SpellOne) //KneeBreaker
        {
            if (foes.Style == 0)
            {
                foes.Hp -= (15 * 2);
            }
            else if (foes.Style == 1)
            {
                foes.Hp -= (15 / 2);
            }
            else
            {
                foes.Hp -= 15;
            }
        }
        if (Ability == player.SpellTwo) //Uppercut
        {
            if (foes.Style == 2)
            {
                foes.Hp -= (15 * 2);
            }
            else if (foes.Style == 0)
            {
                foes.Hp -= (15 / 2);
            }
            else
            {
                foes.Hp -= 15;
            }
        }
        if (Ability == player.SpellThree) //Flurry Blows
        {
            if (foes.Style == 1)
            {
                foes.Hp -= (15 * 2);
            }
            else if (foes.Style == 2)
            {
                foes.Hp -= (15 / 2);
            }
            else
            {
                foes.Hp -= 15;
            }
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
        ExitCombatPhase();
        Console.WriteLine("Here");
        OnCombatEnd -= UpdateExitCombat;
        }

    
    private Player player = new Player("CLOUD !!!");
    private Foes foes = new Foes();
    private List<string> CombatSceneList = new List<string>();
}