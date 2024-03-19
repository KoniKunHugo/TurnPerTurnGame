// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

Entity player = new Entity();
player.OnTakeDamage += player.UpadateSlider;
player.TakeDamage(50);