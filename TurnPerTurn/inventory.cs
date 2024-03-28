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

    private Dictionary<Potion, int> potions; //pour ranger les potions
    public Dictionary<Potion, int> Potions { get => potions; set => potions = value; }

    private Dictionary<Item, int> items; //pour ranger les objets
    public Dictionary<Item, int> Items { get => items; set => items = value; }

    public Inventory() 
    {
        objects = new Dictionary<Inventory, int>();
        potions = new Dictionary<Potion, int>();
        items = new Dictionary<Item, int>();
    }

    public virtual void Use(Player p)
    {
        p.UseItem(this);
    }
    public virtual void UseHeal(Potion p, Player player)
    {
        p.Use(player);
    }

    public void AddList(Potion cle, int valeur) //pour ajouter un element 
    {
        if (potions != null && objects != null)
        {
            foreach (var kvp in potions)
            {
                //kvp.Key, kvp.Value
                if (kvp.Key.Name == cle.Name)
                {
                    potions[kvp.Key] += valeur;
                    objects[kvp.Key] += valeur;
                    return;
                }
            }
            potions.Add(cle, valeur);
            objects.Add(cle, valeur);
        }
        else
        {
            Console.WriteLine("error: list null");
        }
    }
    public void AddList(Item cle, int valeur) //pour ajouter un element 
    {
        if (items != null && objects != null)
        {
            foreach (var kvp in items)
            {
                //kvp.Key, kvp.Value
                if (kvp.Key.Name == cle.Name)
                {
                    items[kvp.Key] += valeur;
                    objects[kvp.Key] += valeur;
                    return;
                }
            }
            items.Add(cle, valeur);
            objects.Add(cle, valeur);
        }
        else
        {
            Console.WriteLine("error: list null");
        }
    }

    public virtual void RemoveList(Potion cle) //pour supprimer un element
    {
        if (potions != null && objects != null)
        {
            foreach (var kvp in potions)
            {
                //kvp.Key, kvp.Value
                if (kvp.Key.Name == cle.Name)
                {
                    potions[kvp.Key] -= 1;
                    objects[kvp.Key] -= 1;
                    return;
                }
            }
        }
        else
        {
            Console.WriteLine("error: list null");
        }
    }
    public virtual void RemoveList(Item cle) //pour supprimer un element
    {
        p.UseItem(this);
    }
    public virtual void UseHeal(Player p)
    {
        p.UseItem(this);
        if (items != null && objects != null)
        {
            foreach (var kvp in items)
            {
                //kvp.Key, kvp.Value
                if (kvp.Key.Name == cle.Name)
                {
                    items[kvp.Key] -= 1;
                    objects[kvp.Key] -= 1;
                    return;
                }
            }
        }
        else
        {
            Console.WriteLine("error: list null");
        }
    }
}
