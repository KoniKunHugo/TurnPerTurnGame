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
        Console.WriteLine("Choisis le nom de ton joueur");
        string _name = Console.ReadLine();
        bool isName = false;

        do
        {
            if (string.IsNullOrWhiteSpace(_name))
            {
                Console.WriteLine("erreur, rentre un nom valide");
                _name = Console.ReadLine();
            }
            else
            {
                isName = true;
            }

        
        } while (isName == false);

        CombatPhase combatPhase = new CombatPhase();
        Player player = new Player(_name);
        Console.WriteLine("ton player est " + player.Name);
        player.OnTakeDamage += player.UpdateHit;
        player.OnDeath += player.UpdateDeath;
        player.TakeDamage(5);


        Inventory items = new Inventory();
        items.Objects = new Dictionary<Inventory, int>();
        Potion potion1 = new Potion("heal");
        items.AddList(potion1, 1);
        Item clé = new Item("clé");
        items.AddList(clé, 1);

        Potion potion2 = new Potion("heal");
        items.AddList(potion2, 1);

        
 
        Console.WriteLine("debut loop");
        while (true)
        { 
            while(paused == false)
            {
                while(map && (paused == false))
                {
                    Console.Clear();
                    Console.WriteLine("map");
                    key = Console.ReadKey(true);
                    if (key.Key == ConsoleKey.Z)
                    {

                    }
                    if (key.Key == ConsoleKey.S)
                    {

                    }
                    if (key.Key == ConsoleKey.Q)
                    {

                    }
                    if (key.Key == ConsoleKey.D)
                    {

                    }
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
                }
                while (fight && (paused == false))
                {
                    Console.Clear();
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
                    Console.WriteLine("c'est en pause");
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
                    Console.WriteLine("fin pause");
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
                        Console.WriteLine("HP : " + player.Allies[0].Hp);
                        Console.WriteLine("Damage : " + player.Allies[0].Damage);
                        Console.WriteLine("Speed : " + player.Allies[0].Speed);
                        Console.WriteLine("Experience : " + player.Allies[0].XP + " :\n");
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
                        Console.WriteLine("fin pause");
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
                            int i = 1;
                            foreach (KeyValuePair<Inventory, int> kvp in items.Objects)
                            {
                                //Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
                                Console.Write(i + ")" + kvp.Key.Name + "  nombre : " + kvp.Value + " \n");
                                i++;
                            }
                        }
                    }
                    key = Console.ReadKey(true);
                    if (key.Key == ConsoleKey.D0 || key.Key == ConsoleKey.NumPad0)
                    {
                        Console.Clear();
                        //Console.WriteLine(items.Objects[0].Name);
                        Console.WriteLine("Attaques :\n");
                    }

                    if (key.Key == ConsoleKey.Escape) //escape pour quitter la pause
                    {
                        paused = false;
                        inventaire = false;
                        Console.WriteLine("fin pause");
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