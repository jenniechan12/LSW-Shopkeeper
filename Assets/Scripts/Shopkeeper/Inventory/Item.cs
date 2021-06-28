using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Item Class
public class Item
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
}

// Clothes Class
public enum ClothingType { HAT, TOP, BOTTOM, DRESSES, SHOES, ACCESSORIES, BAGS, OTHER };

public class Clothes : Item
{
    public Sprite Icon;
    public ClothingType Type { get; set; }

    public Clothes()
    {
        Icon = null;
        Name = "White Shirt";
        Description = "Hipster Shirt";
        Price = 10;
        Type = ClothingType.TOP;
    }

    public Clothes(Sprite _sprite, string _name, string _description, int _price, ClothingType _type)
    {
        Icon = _sprite;
        Name = _name;
        Description = _description;
        Price = _price;
        Type = _type;
    }
}
