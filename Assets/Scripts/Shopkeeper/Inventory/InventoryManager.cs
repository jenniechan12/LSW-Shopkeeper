using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InventoryManager : MonoBehaviour
{
    private ItemInventoryUI itemInventoryUI;
    public enum InventoryType { BUY, SELL, FIT };

    public List<Clothes> ClothingsList;
    private InventoryType inventoryType;

    // Player Informations
    private int totalPrice;
    private List<Clothes> playerCart;
    private PlayerManager playerManager;

    private UnityAction SetUpBuy;
    private UnityAction SetUpSell;

    void Start()
    {
        // References to Scripts / Initalizes Variables
        playerManager = GameObject.Find("GameManager").GetComponent<PlayerManager>();
        playerCart = new List<Clothes>();

        // Clone Clothings Database to List
        ClothingsList = new List<Clothes>(DataManager.instance.ClothingsDatabase);


        // Set Up Clothing Inventory UI
        itemInventoryUI = GetComponent<ItemInventoryUI>();
        itemInventoryUI.SetUpClothingInventory(ClothingsList);
    }

    void OnEnable()
    {
        // Set Up UnityAction
        if (SetUpBuy == null) SetUpBuy = new UnityAction(SetUpBuyInventory);
        if (SetUpSell == null) SetUpSell = new UnityAction(SetUpSellInventory);

        EventManager.StartListening("SetUpBuyItems", SetUpBuy);
        EventManager.StartListening("SetUpSellItems", SetUpSell);
    }
    void OnDisable()
    {
        EventManager.StopListening("SetUpBuyItems", SetUpBuy);
        EventManager.StopListening("SetUpSellItems", SetUpSell);
    }

    private void SetUpBuyInventory()
    {
        ClothingsList.Clear();
        ClothingsList = new List<Clothes>(DataManager.instance.ClothingsDatabase);
        itemInventoryUI.SetUpClothingInventory(ClothingsList);
        inventoryType = InventoryType.BUY;
    }
    private void SetUpSellInventory()
    {
        ClothingsList.Clear();
        ClothingsList = new List<Clothes>(playerManager.player.Inventory.ClothingsBag);
        itemInventoryUI.SetUpClothingInventory(ClothingsList);
        inventoryType = InventoryType.SELL;
    }


    public void UpdateInventory(ClothingType _type)
    {
        ClothingsList.Clear();

        // Update Inventory for Buying Items
        if (inventoryType == InventoryType.BUY)
        {
            if (_type != ClothingType.NONE) ClothingsList = DataManager.instance.ClothingsDatabase.FindAll(delegate (Clothes clothes) { return clothes.Type == _type; });
            else ClothingsList = new List<Clothes>(DataManager.instance.ClothingsDatabase);
        }

        // Update Inventory for Selling Items or for Fitting 
        else if (inventoryType == InventoryType.SELL || inventoryType == InventoryType.FIT)
        {
            if (_type != ClothingType.NONE) ClothingsList = playerManager.player.Inventory.ClothingsBag.FindAll(delegate (Clothes clothes) { return clothes.Type == _type; });
            else ClothingsList = new List<Clothes>(playerManager.player.Inventory.ClothingsBag);
        }

        itemInventoryUI.UpdateClothingInventory(ClothingsList);
    }

    public void UpdateTotalPrice(int _price)
    {
        totalPrice += _price;
        itemInventoryUI.totalPriceText.text = totalPrice.ToString();

        // Disable/Enable Purchase button based on Player's ability to pay up
        if (totalPrice > playerManager.player.Inventory.Currency)
        {
            itemInventoryUI.PurchaseButton.interactable = false;
        }
        if (totalPrice <= playerManager.player.Inventory.Currency && !itemInventoryUI.PurchaseButton.interactable)
        {
            itemInventoryUI.PurchaseButton.interactable = true;
        }
    }

    public void AddItemToCart(Clothes _item)
    {
        playerCart.Add(_item);
    }
    public void RemoveItemFromCart(Clothes _item)
    {
        playerCart.Remove(_item);
    }
    private void ClearCart()
    {
        totalPrice = 0;
        itemInventoryUI.totalPriceText.text = totalPrice.ToString();
        playerCart.Clear();

        EventManager.TriggerEvent("ResetCart");
    }

    public void BuyItems()
    {
        int currency = playerManager.player.Inventory.Currency;
        currency -= totalPrice;

        // Update Player's Currency
        playerManager.UpdatePlayerCurrency(currency);
        itemInventoryUI.UpdatePlayerCurrency(currency);

        // Update Player's Cart
        playerManager.AddItemsToInventory(playerCart);
        ClearCart();
    }
    public void SellItems()
    {
        int currency = playerManager.player.Inventory.Currency;
        currency += totalPrice;

        // Update Player's Currency
        playerManager.UpdatePlayerCurrency(currency);
        itemInventoryUI.UpdatePlayerCurrency(currency);

        // Update Player's Cart
        playerManager.RemoveItemsFromInventory(playerCart);
        itemInventoryUI.UpdatePlayerInventory(playerCart);
        ClearCart();
    }

    public void CloseShop()
    {
        itemInventoryUI.Deactivate();
    }
}
