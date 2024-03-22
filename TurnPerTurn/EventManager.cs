using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ObjectiveC;
using System.Text;
using System.Threading.Tasks;


public static class EventManager
{
    public static event Action OnTakeDamage1;
    public static event Action OnDeath1;



    public static void UpadateHit1()
    {
        Console.WriteLine("oui");
    }

    public static void UpadateDeath1()
    {
        Console.WriteLine("dead");
    }

}

