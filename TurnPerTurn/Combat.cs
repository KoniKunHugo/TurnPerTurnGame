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
        foes.AI_Level = 2;
        Combat();
    }

    public void EnterWildCombatPhase()
    {
        foes.randomFoe();
        DrawCombatPhase();
        foes.AI_Level = 1;
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
                ConsoleKeyInfo key = Console.ReadKey(true);
                Console.WriteLine("Que veux tu faire ?");
                Console.WriteLine("1)Attaquer");
                Console.WriteLine("ESC) pause et inventaire");
                Console.WriteLine("Ou alt A quitter");

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

                    CheckCombatEnd();
                    if (CheckCombatEnd() == true)
                    {
                        break;
                    }
                    //FOE ACT SECOND
                    FoesTakesAction();
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
                FoesTakesAction();

                CheckCombatEnd();
                if (CheckCombatEnd() == true)
                {
                    break;
                }

                Console.WriteLine(player.Hp + "Player");
                //PLAYER ACT SECOND


                ConsoleKeyInfo key = Console.ReadKey(true);
                Console.WriteLine("Que veux tu faire ?");
                Console.WriteLine("1)Attaquer");
                Console.WriteLine("ESC) pause et inventaire");

                if (key.Key == ConsoleKey.Escape) //pause
                {
                    Program.Paused = true;
                    break;
                }

                if (((key.Modifiers) == ConsoleModifiers.Alt) && (key.Key == ConsoleKey.A)) //quit
                {
                    Console.WriteLine("application quitt�");
                    return;
                }

                if (key.Key == ConsoleKey.D1 || key.Key == ConsoleKey.NumPad1)
                {


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

                    CheckCombatEnd();
                    if (CheckCombatEnd() == true)
                    {
                        break;
                    }

                }
            }
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
            //Kill
        }
        else if (foes.Hp <= 0)
        {
            player.XP += 50;
            player.LevelUp();
        }
        Console.WriteLine("end fight");
    }

    public void UpdateExitCombat()
        {
        ExitCombatPhase();
        Program.Fight = false;
        Program._Map = true;
        OnCombatEnd -= UpdateExitCombat;
        }

    
    private Player player = new Player("CLOUD !!!");
    private Foes foes = new Foes();
    private List<string> CombatSceneList = new List<string>();
}