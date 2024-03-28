 class Program
{
    private static ConsoleKeyInfo key;
    public ConsoleKeyInfo Key { get => key; set => key = value; }


    private static bool paused = false;
    public static bool Paused { get => paused; set => paused = value; }

    private static bool equipe = false;
    private static bool inventaire = false;

    private static bool fight = false;
    public static bool Fight { get => fight; set => fight = value; }

    private static bool map = true;
    public static bool _Map { get => map; set => map = value; }
    private static bool once = true;

    static int Main(string[] args)
    {
        Console.WindowWidth = 240;
        Console.WindowHeight = 60;
        Console.CursorVisible = false;
        Console.WriteLine("Choisis le nom de ton joueur");
        string name = Console.ReadLine();
        bool isName = false;

        do
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("erreur, rentre un nom valide");
                name = Console.ReadLine();
            }
            else
            {
                isName = true;
            }

        
        } while (isName == false);

        CombatPhase combatPhase = new CombatPhase();
        Player player = new Player(name);
        Console.WriteLine("ton player est " + player.Name);
        player.OnTakeDamage += player.UpdateHit;
        player.OnDeath += player.UpdateDeath;
        player.TakeDamage(5);


        Inventory items = new Inventory();
        Potion potion1 = new Potion("heal");
        items.AddList(potion1, 1);
        Item clé = new Item("clé");
        items.AddList(clé, 1);

        Potion potion2 = new Potion("heal");
        items.AddList(potion2, 1);

        Console.WriteLine("debut loop");
        Console.Clear();
        Map.MapColor();
        while (true)
        { 
            while(paused == false)
            {
                while(map && (paused == false))
                {
                    key = Console.ReadKey(true);
                    if (key.Key == ConsoleKey.Escape) //pause
                    {
                        paused = true;
                    }
                    if (((key.Modifiers) == ConsoleModifiers.Alt) && (key.Key == ConsoleKey.A)) //quit
                    {
                        Console.WriteLine("application quitté");
                        return 0;
                    }
                    if (key.Key == ConsoleKey.Enter) //fight switch
                    {
                        fight = true;
                        map = false;
                    }
                    Input.IsInput();
                }
                if (Input.Fight > 7 && (paused == false))
                {
                    fight = true;
                    Console.WriteLine("fight");
                    combatPhase.EnterWildCombatPhase();
                }
            }

            while(paused)
            {
                do
                {
                    once = false;
                    Console.Clear();
                    Console.WriteLine("?C'est en pause");
                    Console.WriteLine("Que veux tu faire ?");
                    Console.WriteLine("1)Afficher l'équipe");
                    Console.WriteLine("2)Afficher l'inventaire");
                    Console.WriteLine("3)Sauvegarder (Beta)");
                    Console.WriteLine("echap fin pause ou alt A quitter");
                } while (once);
                
                key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.D1 || key.Key == ConsoleKey.NumPad1) // 1 pour voir l'equipe
                {
                    equipe = true;
                    paused = false;
                    once = true;
                }
                if (key.Key == ConsoleKey.D2 || key.Key == ConsoleKey.NumPad2) // 2 pour voir l'inventaire
                {
                    inventaire = true;
                    paused = false;
                    once = true;
                }
                if (key.Key == ConsoleKey.D3 || key.Key == ConsoleKey.NumPad3) // 3 pour save
                {
                    Console.WriteLine("save :");
                }
                if (key.Key == ConsoleKey.Escape) //escape pour quitter la pause
                {
                    paused = false;
                    once = true;
                    Console.Clear();
                    Map.MapColor();
                    Console.CursorVisible = false;
                }
                if (((key.Modifiers) == ConsoleModifiers.Alt) && (key.Key == ConsoleKey.A)) //quit
                {
                    Console.WriteLine("application quitté");
                    return 0;
                }

                while (equipe) //equipe
                {
                    while(once)
                    {
                        once = false;
                        Console.Clear();
                        Console.WriteLine("membre de l'équipe (backspace pour revenir au menu) :");
                        for (int i = 0; i < player.Allies.Count; i++)
                        {
                            Console.Write(i + ")" + player.Allies[i].Name + " \n");
                        }
                    }
                    
                    key = Console.ReadKey(true);
                    if (key.Key == ConsoleKey.D0 || key.Key == ConsoleKey.NumPad0)
                    {
                        Console.Clear();
                        Console.WriteLine(player.Allies[0].Name + " :\n");
                        Console.WriteLine("Level : " + player.Allies[0].Level);
                        Console.WriteLine("HP : " + player.Allies[0].Hp + "/" + player.Allies[0].MaxHp);
                        Console.WriteLine("Damage : " + player.Allies[0].Damage);
                        Console.WriteLine("Speed : " + player.Allies[0].Speed);
                        Console.WriteLine("Experience : " + player.Allies[0].XP + " \n");
                        Console.WriteLine("Attaques :\n");
                        for (int i = 0; i < player.Attacks.Count; i++)
                        {
                            Console.WriteLine(player.Allies[0].Attacks[i].ToString());
                        }
                    }
                    if (key.Key == ConsoleKey.Escape) //escape pour quitter la pause
                    {
                        paused = false;
                        equipe = false;
                        once = true;
                        Console.Clear();
                        Map.MapColor();
                        Console.CursorVisible = false;
                    }
                    if (key.Key == ConsoleKey.Backspace) //escape pour quitter l'equipe et revenir au menu
                    {
                        equipe = false;
                        paused = true;
                        once = true;
                        Console.WriteLine("fin equipe");
                    }
                    if (((key.Modifiers) == ConsoleModifiers.Alt) && (key.Key == ConsoleKey.A)) //quit
                    {
                        Console.WriteLine("application quitté");
                        return 0;
                    }
                }
                while (inventaire) //inventaire
                {
                    while(once)
                    {
                        once = false;
                        Console.Clear();
                        Console.WriteLine("objets de l'inventaire (backspace pour revenir au menu) :");
                        if (items.Objects == null)
                        {
                            Console.WriteLine("vous n'avez pas d'objet");
                        }
                        else
                        {
                            int i = 0;
                            foreach (KeyValuePair<Inventory, int> kvp in items.Objects)
                            {
                                Console.Write(i + ")" + kvp.Key.Name + "  nombre : " + kvp.Value + " \n");
                                i++;
                            }
                        }
                    }
                    key = Console.ReadKey(true);
                    if (key.Key == ConsoleKey.D0 || key.Key == ConsoleKey.NumPad0)
                    {
                        Console.Clear();
                        Console.WriteLine("potions :\n");
                        Console.WriteLine(items.Potions.ElementAt(0).Key);
                        Console.WriteLine("nombre :\n");
                        Console.WriteLine(items.Potions.ElementAt(0).Value);
                        Console.WriteLine(" appuyer sur ENTRER pour l'utiliser");

                        key = Console.ReadKey(true);
                        if (key.Key == ConsoleKey.Enter)
                        {
                            Console.WriteLine(items.Objects.ElementAt(0).Key);
                            items.Objects.ElementAt(0).Key.UseHeal(potion1,player);
                            items.RemoveList(potion1);
                            Console.WriteLine("objet utilisé");

                            int i = 0;
                            foreach (KeyValuePair<Inventory, int> kvp in items.Objects)
                            {
                                Console.Write(i + ")" + kvp.Key.Name + "  nombre : " + kvp.Value + " \n");
                                i++;
                            }
                        }
                    }
                    if (key.Key == ConsoleKey.D1 || key.Key == ConsoleKey.NumPad1)
                    {
                        Console.Clear();
                        Console.WriteLine("objets :\n");
                        Console.WriteLine(items.Items.ElementAt(0).Key);
                        Console.WriteLine("nombre :\n");
                        Console.WriteLine(items.Items.ElementAt(0).Value);
                        Console.WriteLine(" appuyer sur ENTRER pour l'utiliser");

                        key = Console.ReadKey(true);
                        if (key.Key == ConsoleKey.Enter)
                        {
                            Console.WriteLine(items.Items.ElementAt(0).Key);
                            items.Items.ElementAt(0).Key.Use(player);
                            items.RemoveList(clé);
                            Console.WriteLine("objet utilisé");

                            int i = 0;
                            foreach (KeyValuePair<Inventory, int> kvp in items.Objects)
                            {
                                Console.Write(i + ")" + kvp.Key.Name + "  nombre : " + kvp.Value + " \n");
                                i++;
                            }
                        }
                    }

                    if (key.Key == ConsoleKey.Escape) //escape pour quitter la pause
                    {
                        paused = false;
                        inventaire = false;
                        Console.Clear();
                        Map.MapColor();
                        Console.CursorVisible = false;
                    }
                    if (key.Key == ConsoleKey.Backspace) //escape pour quitter l'inventaire et revenir au menu
                    {
                        inventaire = false;
                        paused = true;
                        Console.WriteLine("fin inventaire");
                    }
                    if (((key.Modifiers) == ConsoleModifiers.Alt) && (key.Key == ConsoleKey.A)) //quit
                    {
                        Console.WriteLine("application quitté");
                        return 0;
                    }
                }
            }
        }
    }
}
