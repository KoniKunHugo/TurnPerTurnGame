using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

class CombatPhase
{
    //public event Action OnCombatEnd;

    public void EnterWildCombatPhase()
    {
        foes.randomFoe();
        DrawCombatPhase();
        foes.AI_Level = 1;
        Combat();
    }

    public void EnterPredeterminedCombatPhase()
    {
        //We'll choose manually
        DrawCombatPhase();
        foes.AI_Level = 2;
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
            DrawCombatPhase();
            //PLAYER ACT FIRST
            if (player.Speed > foes.Speed)
            {
                Console.WriteLine("Que veux tu faire ?\n");
                Console.WriteLine("1)Attaquer");
                Console.WriteLine("ESC) pause et inventaire");
                Console.WriteLine("Ou alt A quitter");
                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.Escape) //pause
                {
                    Program.Paused = true;
                    break;
                }
                if (((key.Modifiers) == ConsoleModifiers.Alt) && (key.Key == ConsoleKey.A)) //quit
                {
                    Console.WriteLine("APP QUITTED !");
                    return;
                }
                if (key.Key == ConsoleKey.D1 || key.Key == ConsoleKey.NumPad1)
                {
                    //PLAYER ACT FIRST
                    Console.WriteLine(player.Hp + "Player");
                    Console.WriteLine("Show them Your Moves");
                    Console.WriteLine("-" + player.SpellOne);
                    Console.WriteLine("-" + player.SpellTwo);
                    Console.WriteLine("-" + player.SpellThree);
                    Console.WriteLine("-" + player.SpellFour);

                    PlayerTakesAction();
                    

                    CheckCombatEnd();
                    if (CheckCombatEnd() == true)
                    {
                        break;
                    }
                    //FOE ACT SECOND
                    if (Skip == 1) {
                        Skip = 0;
                    }
                    else {
                        FoesTakesAction();
                    }


                    CheckCombatEnd();
                    if (CheckCombatEnd() == true)
                    {
                        break;
                    }
                } 
            }
            else
            {
                //FOE ACT FIRST
                if (Skip == 1){
                    Skip = 0;
                }
                else
                {
                    FoesTakesAction();
                }

                CheckCombatEnd();
                if (CheckCombatEnd() == true)
                {
                    break;
                }

                Console.WriteLine(player.Hp + " Player");
                //PLAYER ACT SECOND

                Console.WriteLine("Que veux tu faire ?\n");
                Console.WriteLine("1)Attaquer");
                Console.WriteLine("ESC) pause et inventaire");
                Console.WriteLine("Ou alt A quitter");
                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.Escape) //pause
                {
                    Program.Paused = true;
                    Skip = 1;
                    break;
                }

                if (((key.Modifiers) == ConsoleModifiers.Alt) && (key.Key == ConsoleKey.A)) //quit
                {
                    Console.WriteLine("application quitt�");
                    return;
                }

                if (key.Key == ConsoleKey.D1 || key.Key == ConsoleKey.NumPad1)
                {
                    
                    PlayerTakesAction();

                    CheckCombatEnd();
                    if (CheckCombatEnd() == true)
                    {
                        break;
                    }

                }
            }
        }
    }
    public bool PlayerTakesAction()
    {
        Console.WriteLine("Show them Your Moves");
        Console.WriteLine("- 1) " + player.SpellOne);
        Console.WriteLine("- 2) " + player.SpellTwo);
        Console.WriteLine("- 3) " + player.SpellThree);
        Console.WriteLine("- 4) " + player.SpellFour + "\n");

        ConsoleKeyInfo key = Console.ReadKey(true);

        if (key.Key == ConsoleKey.D1 || key.Key == ConsoleKey.NumPad1) { CheckAbility(1); return true; }
        else if (key.Key == ConsoleKey.D2 || key.Key == ConsoleKey.NumPad2) { CheckAbility(2); return true; }
        else if (key.Key == ConsoleKey.D3 || key.Key == ConsoleKey.NumPad3) { CheckAbility(3); return true; }
        else if (key.Key == ConsoleKey.D4 || key.Key == ConsoleKey.NumPad4) { CheckAbility(4); return true; }
        else
        {
            Console.WriteLine("1, 2, 3 or 4");
            Thread.Sleep(500);
            return false;
        }
    }

    public void FoesTakesAction()
    {
        if (foes.AI_Level == 1)
        {
            player.TakeDamage(foes.Damage);
        }
        if (foes.AI_Level == 2) 
        {
            if (player.Hp < foes.Damage)
            {
                Console.WriteLine("Foe Casted : Swift Blow ");
                player.TakeDamage(foes.Damage);
            }
            if (player.Damage < foes.Hp)
            {
                Console.WriteLine("Foe Casted : Enrage ");
                foes.Damage *= 2;
            }
            Console.WriteLine("We Got Here once");
        }
        Thread.Sleep(1500);
    }

    public void CheckAbility(int Spell)
    {
        if (Spell == 1) //KneeBreaker
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
        if (Spell == 2) //Uppercut
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
        if (Spell == 3) //Flurry Blows
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
        if (Spell == 4)
        {
            player.Damage = player.Damage + 10;
        }
        Thread.Sleep(1500);
    }

    public bool CheckCombatEnd()
    {
        if (foes.Hp <= 0 || player.Hp <= 0)
        {
            UpdateExitCombat();
            return true;
        }
        return false;
    }

    public void ExitCombatPhase()
    {
        if (player.Hp <= 0)
        {
            Console.WriteLine("You died");

        }
        else if (foes.Hp <= 0)
        {
            player.XP += 50;
            player.LevelUp();
        }
        Console.WriteLine("end fight");
        Thread.Sleep(2000);
    }

    public void UpdateExitCombat()
        {
        ExitCombatPhase();
        Program.Fight = false;
        Program._Map = true;
        //OnCombatEnd -= UpdateExitCombat;
        }

    private int Skip;
    private Player player = new Player("CLOUD !!!");
    private Foes foes = new Foes();
    private List<string> CombatSceneList = new List<string>();
}