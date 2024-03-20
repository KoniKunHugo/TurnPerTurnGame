// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

Entity player = new Entity();
player.OnTakeDamage += player.UpadateHit;
player.OnDeath += player.UpadateDeath;

Foes ennemy1 = new Foes();
ennemy1.OnTakeDamage += ennemy1.UpadateHit;
ennemy1.OnDeath += ennemy1.UpadateDeath;
ennemy1.TakeDamage(50);
