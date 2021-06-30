using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Player
{
    public string Name;
    public PlayerGraphics Outfit;
    public PlayerInventory Inventory;

    public Player()
    {
        Name = "Keira";
    }

    public Player(string _name)
    {
        Name = _name;
    }
}

[System.Serializable]
public class PlayerGraphics
{
    public Sprite Top;
    public Sprite Bottom;
    public Sprite Shoe;

    public void StarterPack(Sprite _top, Sprite _bottom, Sprite _shoe)
    {
        Top = _top;
        Bottom = _bottom;
        Shoe = _shoe;
    }
}

[System.Serializable]
public class PlayerInventory
{
    public int Currency;
    public List<Clothes> ClothingsBag;

    public PlayerInventory()
    {
        Currency = 10000;
        ClothingsBag = new List<Clothes>();
    }
}
