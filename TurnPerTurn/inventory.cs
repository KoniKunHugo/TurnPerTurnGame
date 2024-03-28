using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

public class Inventory
{
    private string name;
    public string Name { get => name; set => name = value; }

    private Dictionary<Inventory,int> objects; //dictionnaire pour ranger les potions/items et leurs nombre
    public Dictionary<Inventory, int> Objects { get => objects; set => objects = value; }

    public Inventory() 
    {
    
    }

    public void AddList(Inventory cle, int valeur) //pour ajouter un element 
    {
        if (Objects != null) 
        {
            foreach (var kvp in Objects)
            {
                //kvp.Key, kvp.Value
                if (kvp.Key.Name == cle.Name)
                {
                    Objects[kvp.Key] += valeur;
                    return;
                }
            }
            Objects.Add(cle, valeur);
        }
        else
        {
            Console.WriteLine("error: list null");
        }
    }

    public void RemoveList(Inventory cle, int valeur) //pour supprimer un element
    {
        if (Objects != null)
        {
            foreach (var kvp in Objects)
            {
                //kvp.Key, kvp.Value
                if (kvp.Key.Name == cle.Name)
                {
                    Objects[kvp.Key] -= valeur;
                    return;
                }
            }
        }
        else
        {
            Console.WriteLine("error: list null");
        }
    }

    public virtual void Use(Player p)
    {
        p.UseItem(this);
    }
    public virtual void UseHeal(Player p)
    {
        p.UseItem(this);
    }
}
