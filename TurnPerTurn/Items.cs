using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



public class Items : Inventory
{

    private string name;
    public string Name { get => name; }

    private List<Items> objects;
    public List<Items> Objects { get => objects; set => objects = value; }
}

