public static class Input
{
    public static void IsInput()
    {
        ConsoleKeyInfo key;
        bool paused = false;
        do
        {
            key = Console.ReadKey();
            Console.Write(" --- You pressed ");
            if (key.Key == ConsoleKey.Z) Console.Write("Z");
            if (key.Key == ConsoleKey.S) Console.Write("S");
            if (key.Key == ConsoleKey.Q) Console.Write("Q");
            if (key.Key == ConsoleKey.D) Console.Write("D");
            if (key.Key == ConsoleKey.Escape) //pause
            {
                paused = true;
            }
            Console.WriteLine(key.Key.ToString());
        } while (paused == false);

        //menu 
        while (paused == true);
        {
            Console.WriteLine("c'est en pause");
            if (key.Key == ConsoleKey.Escape) //pause
            {
                paused = false;
            }
        }
    }    
}