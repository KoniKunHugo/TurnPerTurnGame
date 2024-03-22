// See https://aka.ms/new-console-template for more information

class Program
{
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

        Player player = new Player(_name);
        Console.WriteLine("ton player est " + player.Name);
        player.OnTakeDamage += player.UpadateHit;
        player.OnDeath += player.UpadateDeath;
        player.TakeDamage(5);

        Foes ennemy1 = new Foes(2);
        ennemy1.OnTakeDamage += ennemy1.UpadateHit;
        ennemy1.OnDeath += ennemy1.UpadateDeath;
        ennemy1.TakeDamage(50);
        Console.WriteLine("debut loop");

        Inventory items = new Inventory();
        items.Objects = new Dictionary<Inventory, int>();
        Potion potion1 = new Potion("heal");
        items.AddList(potion1, 1);
        Item clé = new Item("clé");
        items.AddList(clé, 1);

        Potion potion2 = new Potion("heal");
        items.AddList(potion2, 1);

        ConsoleKeyInfo key;
        bool paused = false;
        bool equipe = false;
        bool inventaire = false;
        while (true)
        { 
            do //map
            {
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
            } while (paused == false);

            Console.WriteLine("c'est en pause");
            Console.WriteLine("Que veux tu faire ?");
            Console.WriteLine("1)Afficher l'équipe");
            Console.WriteLine("2)Afficher l'inventaire");
            Console.WriteLine("3)Sauvegarder (Beta)");
            Console.WriteLine("echap fin pause ou alt A quitter");


            do //pause
            {
                key = Console.ReadKey(true);
                Console.Clear();

                if (key.Key == ConsoleKey.D1 || key.Key == ConsoleKey.NumPad1) 
                {
                    equipe = true;
                    paused = false;
                }
                if (key.Key == ConsoleKey.D2 || key.Key == ConsoleKey.NumPad2)
                {
                    inventaire = true;
                    paused = false;
                }
                if (key.Key == ConsoleKey.D3 || key.Key == ConsoleKey.NumPad3)
                {
                    Console.WriteLine("save :");
                }
                if (key.Key == ConsoleKey.Escape)
                {
                    paused = false;
                }
                if (((key.Modifiers) == ConsoleModifiers.Alt) && (key.Key == ConsoleKey.A)) //quit
                {
                    Console.WriteLine("application quitté");
                    return 0;
                }
            } while (paused == true);
            Console.WriteLine("fin pause");

            if (equipe) //equipe
            {
                Console.WriteLine("membre de l'équipe : ");
                for (int i = 0; i < player.Allies.Count; i++)
                {
                    Console.Write(i + ")" +player.Allies[i].Name + " \n");
                }
                key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.D0 || key.Key == ConsoleKey.NumPad0)
                {
                    Console.Clear();
                    Console.WriteLine(player.Allies[0].Name + " :\n");
                    Console.WriteLine("Level : " +player.Allies[0].Level );
                    Console.WriteLine("HP : " + player.Allies[0].Hp );
                    Console.WriteLine("Damage : " + player.Allies[0].Damage);
                    Console.WriteLine("Speed : " + player.Allies[0].Speed);
                    Console.WriteLine("Experience : " + player.Allies[0].Xp + " :\n");
                    Console.WriteLine("Attaques :\n");
                    for (int i = 0;i < player.Attacks.Count;i++) 
                    {
                        Console.WriteLine(player.Allies[0].Attacks[i].ToString());
                    }
                }
            }
            if (inventaire) //inventaire
            {
                Console.WriteLine("objets de l'inventaire : ");
                if ( items.Objects == null)
                {
                    Console.WriteLine("vous n'avez pas d'objet");
                }
                else
                {
                    int i = 1;
                    foreach (KeyValuePair<Inventory, int> kvp in items.Objects)
                    {
                        //Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
                        Console.Write(i + ")" + kvp.Key.Name +"  nombre : " + kvp.Value + " \n");
                        i++;
                    }
                }
            }
            if (((key.Modifiers) == ConsoleModifiers.Alt) && (key.Key == ConsoleKey.A)) //quit
            {
                Console.WriteLine("application quitté");
                return 0;
            }
        }
    }
}

