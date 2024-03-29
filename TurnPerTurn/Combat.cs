using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

class CombatPhase
{
     public void EnterWildCombatPhase()
    {
        Console.Clear();
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
        ConsoleKeyInfo key;
        bool playerIsFast = (player.Speed >= foes.Speed);
        while (Program.Fight)
        {
            DrawCombatPhase();
            //PLAYER ACT FIRST
            if (playerIsFast)
            {
                Console.WriteLine("Que veux tu faire ?\n");
                Console.WriteLine("1)Attaquer");
                Console.WriteLine("ESC) pause et inventaire");
                Console.WriteLine("Alt A) quitter");
                key = Console.ReadKey();

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
                    do
                    {
                        if (PlayerTakesAction() == false)
                        {
                            Skip = 1;
                            Console.WriteLine("n'oublie pas de jouer");
                        }
                            
                    } while (Skip == 1);

                    Console.WriteLine(foes.Hp + "pv Mob");
                    Console.WriteLine(player.Hp + "pv Player");

                    if (CheckCombatEnd() == true)
                    {
                        break;
                    }
                    //FOE ACT SECOND
                    if (Skip == 1)
                    {
                        Skip = 0;
                    }
                    else
                    {
                        FoesTakesAction();
                    }

                    if (CheckCombatEnd() == true)
                    {
                        break;
                    }
                }
            }
            else
            {
                //FOE ACT FIRST
                if (Skip == 1)
                {
                    Skip = 0;
                }
                else
                {
                    FoesTakesAction();
                }

                if (CheckCombatEnd() == true)
                {
                    break;
                }

                Console.WriteLine(player.Hp + " Player");
                //PLAYER ACT SECOND

                Console.WriteLine("Que veux tu faire ?\n");
                Console.WriteLine("1)Attaquer");
                Console.WriteLine("ESC) pause et inventaire");
                Console.WriteLine("Alt A) quitter");
                key = Console.ReadKey();

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

                if (key.Key == ConsoleKey.D1 || key.Key == ConsoleKey.NumPad1)
                {

                    do
                    {
                        if (PlayerTakesAction() == false)
                        {
                            Skip = 1;
                            Console.WriteLine("n'oublie pas de jouer");
                        }

                    } while (Skip == 1);

                    Console.WriteLine("\n"+foes.Hp + "pv Mob");
                    Console.WriteLine(player.Hp + "pv Player");

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

        ConsoleKeyInfo key = Console.ReadKey();

        if (key.Key == ConsoleKey.A ) { CheckAbility(1); return true; }
        else if (key.Key == ConsoleKey.Z ) { CheckAbility(2); return true; }
        else if (key.Key == ConsoleKey.E) { CheckAbility(3); return true; }
        else if (key.Key == ConsoleKey.R) { CheckAbility(4); return true; }
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
        else if (foes.AI_Level == 2)
        {
            if (player.Hp < foes.Damage)
            {
                Console.WriteLine("Foe Casted : Swift Blow ");
                player.TakeDamage(foes.Damage);
            }
            else
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
            Console.WriteLine("end fight");
            Thread.Sleep(2000);
            Console.Clear();
            Map.GameOver();
            Thread.Sleep(5000);
        }
        else if (foes.Hp <= 0)
        {
            player.XP += 50;
            player.LevelUp();
            Console.WriteLine("end fight");
            Thread.Sleep(2000);
            Console.Clear();
            Input.Curx = 30;
            Input.Cury = 160;
            Input.Fight = 0;
            Map.MapColor();
        }
    }

    public void UpdateExitCombat()
    {
        ExitCombatPhase();
        Program.Fight = false;
        Program._Map = true;
    }

    private int Skip;
    private Player player = new Player("CLOUD !!!");
    private Foes foes = new Foes();
    private List<string> CombatSceneList = new List<string>();
}