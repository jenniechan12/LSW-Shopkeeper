using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    private ItemInventoryUI itemInventoryUI;

    public List<Clothes> ClothingsList;
    private int totalPrice;

    private GameManager gameManager;


    void Start()
    {
        gameManager = GameManager.instance;

        itemInventoryUI = GetComponent<ItemInventoryUI>();
        ClothingsList = new List<Clothes>(DataManager.instance.ClothingsDatabase);
        itemInventoryUI.SetUpClothingInventory(ClothingsList);
    }

    public void UpdateInventory(ClothingType _type)
    {
        ClothingsList.Clear();

        if (_type != ClothingType.NONE) ClothingsList = DataManager.instance.ClothingsDatabase.FindAll(delegate (Clothes clothes) { return clothes.Type == _type; });
        else ClothingsList = new List<Clothes>(DataManager.instance.ClothingsDatabase);
        itemInventoryUI.UpdateClothingInventory(ClothingsList);
    }

    public void UpdateTotalPrice(int _price)
    {
        totalPrice += _price;
        itemInventoryUI.totalPriceText.text = totalPrice.ToString();
    }

    public void BuyItems()
    {
        int currency = gameManager.player.Inventory.Currency;
        currency -= totalPrice;
        itemInventoryUI.UpdatePlayerCurrency(currency);
    }

    public void SellItems()
    {
        int currency = gameManager.player.Inventory.Currency;
        currency += totalPrice;
        itemInventoryUI.UpdatePlayerCurrency(currency);
    }

    public void CloseShop()
    {
        itemInventoryUI.Deactivate();
    }
}
