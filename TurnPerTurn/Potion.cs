using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Potion : Inventory
{
    public
       Potion(string _name)
    {
        Name = _name;
        
    }

    public override void Use(Player p)
    {
        p.Heal(5);
        //Objects.Remove(this);
    }
}

