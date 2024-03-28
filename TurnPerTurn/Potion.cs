using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Potion : Inventory
{
    private int nHeal;
    public int NHeal { get => nHeal; set => nHeal = value; }

    public
       Potion(string _name)
    {
        nHeal = 5;
        Name = _name;
        
    }

    public override void Use(Player p)
    {
        p.Heal(nHeal);
    }
}

