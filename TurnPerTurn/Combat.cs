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
        while (Program.Fight)
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
                ConsoleKeyInfo key = Console.ReadKey(true);

                if (player.SpellOne == Temp || player.SpellTwo == Temp || player.SpellThree == Temp || player.SpellFour == Temp)
                {
                    Console.WriteLine("Attaque");
                    CheckAbility(Temp);
                    Console.WriteLine(foes.Hp + "Mob");
                    Console.WriteLine(player.Hp + "Player");
                }
                
                if (key.Key == ConsoleKey.Escape) //pause
                {
                    Program.Paused = true;
                    break;
                }
                if (((key.Modifiers) == ConsoleModifiers.Alt) && (key.Key == ConsoleKey.A)) //quit
                {
                    Console.WriteLine("application quitté");
                    return;
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
        if (Ability == player.SpellOne)
        {
            if (foes.Style == 0)
            {
                foes.Hp -= (15 * 2);
            }
            else
            {
                foes.Hp -= 15;
            }
        }
        if (Ability == player.SpellTwo)
        {
            if (foes.Style == 2)
            {
                foes.Hp -= (15 * 2);
            }
            else
            {
                foes.Hp -= 15;
            }
        }
        if (Ability == player.SpellThree)
        {
            if (foes.Style == 1)
            {
                foes.Hp -= (15 * 2);
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
        else if (foes.Hp == 0)
        {
            player.XP += 50;
            player.LevelUp();
        }
        Console.WriteLine("end fight");
    }

    public void UpdateExitCombat()
        {
        Program.Fight = false;
        Program._Map = true; 
        ExitCombatPhase();
        Console.WriteLine("Here");
        OnCombatEnd -= UpdateExitCombat;
        }

    
    private Player player = new Player("CLOUD !!!");
    private Foes foes = new Foes();
    private List<string> CombatSceneList = new List<string>();
}