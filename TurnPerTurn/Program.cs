// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

Player player = new Player("moi");
player.OnTakeDamage += player.UpadateHit;
player.OnDeath += player.UpadateDeath;
player.TakeDamage(5);

Foes ennemy1 = new Foes(2);
ennemy1.OnTakeDamage += ennemy1.UpadateHit;
ennemy1.OnDeath += ennemy1.UpadateDeath;
ennemy1.TakeDamage(50);
