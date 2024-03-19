public class Input
{
    public static void IsInput()
    {
        ConsoleKeyInfo key;
        do
        {
            key = Console.ReadKey();
            Console.Write(" --- You pressed ");
            if (key.Key == ConsoleKey.Z) Console.Write("Z");
            if (key.Key == ConsoleKey.S) Console.Write("S");
            if (key.Key == ConsoleKey.Q) Console.Write("Q");
            if (key.Key == ConsoleKey.D) Console.Write("D");
            Console.WriteLine(key.Key.ToString());
        } while (key.Key != ConsoleKey.Escape);
    }    
}