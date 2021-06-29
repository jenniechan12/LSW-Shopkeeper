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
        Name = "Player1";
    }
}

[System.Serializable]
public class PlayerGraphics
{
    public Sprite Hat;
    public Sprite Top;
    public Sprite Bottom;
    public Sprite Dresses;
    public Sprite Shoe;
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
