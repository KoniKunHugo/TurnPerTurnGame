// See https://aka.ms/new-console-template for more information

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Choisis le nom de ton joueur");
        string _name = Console.ReadLine();
        bool isName = false;

        do
        {
            if (string.IsNullOrWhiteSpace(_name)  )
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
    }
}

