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
        //player.AddList(player);
        Console.WriteLine("ton player est " + player.Name);
        player.OnTakeDamage += player.UpadateHit;
        player.OnDeath += player.UpadateDeath;
        player.TakeDamage(5);

        Foes ennemy1 = new Foes(2);
        ennemy1.OnTakeDamage += ennemy1.UpadateHit;
        ennemy1.OnDeath += ennemy1.UpadateDeath;
        ennemy1.TakeDamage(50);
        Console.WriteLine("debut loop");

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
            Console.WriteLine("1) Afficher l'équipe");
            Console.WriteLine("2) Afficher l'inventaire");
            Console.WriteLine("3)Sauvegarder (Beta)");
            Console.WriteLine("echap fin pause ou alt A quitter");


            do //pause
            {
                key = Console.ReadKey(true);
                
                if (key.Key == ConsoleKey.D1 || key.Key == ConsoleKey.NumPad1) 
                {
                    Console.WriteLine("Equipe :");
                    equipe = true;
                    paused = false;
                }
                if (key.Key == ConsoleKey.D2 || key.Key == ConsoleKey.NumPad2)
                {
                    Console.WriteLine("inventaire :");
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
                    Console.WriteLine("Experience : " + player.Allies[0].Xp);
                }

            }
        }
    }
}

