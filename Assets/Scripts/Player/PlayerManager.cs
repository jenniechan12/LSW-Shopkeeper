using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public Player player;

    void Awake()
    {

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
