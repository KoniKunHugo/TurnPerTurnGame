using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

public class Item : Inventory
{

    public
       Item(string _name)
    {
        Name = _name;
    }

    public override void Use(Player p)
    {
        
    }
}
