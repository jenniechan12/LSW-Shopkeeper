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

    public string TopName;
    public string BottomName;
    public string ShoeName;

    public PlayerGraphics()
    {
        TopName = "White Shirt";
        BottomName = "Blue Jean";
        ShoeName = "White Shoe";
    }

    public void StarterPack(Sprite _top, Sprite _bottom, Sprite _shoe)
    {
        SetTop(_top, "White Shirt");
        SetBottom(_bottom, "Blue Jean");
        SetShoe(_shoe, "White Shoe");
    }
    public void SetTop(Sprite _sprite, string _name)
    {
        Top = _sprite;
        TopName = _name;
    }
    public void SetBottom(Sprite _sprite, string _name)
    {
        Bottom = _sprite;
        BottomName = _name;
    }
    public void SetShoe(Sprite _sprite, string _name)
    {
        Shoe = _sprite;
        ShoeName = _name;
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
