using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public Player player;
    public static PlayerManager instance;

    void Awake()
    {
        // Make sure that DataManager exist in game
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        else if (instance != this)
            Destroy(gameObject);
    }

    public void UpdatePlayerOutfit(Sprite[] _outfit)
    {
        player.Outfit.Top = _outfit[0];
        player.Outfit.Bottom = _outfit[1];
        player.Outfit.Shoe = _outfit[2];
    }
    public void UpdatePlayerCurrency(int _currency)
    {
        player.Inventory.Currency = _currency;
    }

    public void AddItemsToInventory(List<Clothes> _itemList)
    {
        foreach (Clothes item in _itemList)
        {
            player.Inventory.ClothingsBag.Add(item);
        }
    }

    public void RemoveItemsFromInventory(List<Clothes> _itemList)
    {
        List<Clothes> playerItems = player.Inventory.ClothingsBag;

        foreach (Clothes item in _itemList)
        {
            player.Inventory.ClothingsBag.Remove(item);
        }
    }


}
