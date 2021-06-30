using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ItemInventoryUI : MonoBehaviour
{

    // Referencing Scripts 
    private DataManager dataManager;
    private InventoryManager inventoryManager;

    // Referencing UI
    public GameObject InventoryUI, Cart;
    public Button PurchaseButton, SellButton, FitButton;

    // Spawning Item Buttons
    public GameObject itemInventoryPanel;
    public GameObject itemGO;

    // Shopping Cart Variables
    public Text totalPriceText;

    // Player's Currency Variables
    public Text playerCurrencyText;

    // Player's Clothing Selection
    public Image playerTop, playerBottom, playerShoes;
    private bool isTopFound, isBottomFound, isShoeFound;

    // Unity Actions
    private UnityAction SetUpBuy, SetUpSell, SetUpFit;

    // Start is called before the first frame update
    void Start()
    {
        inventoryManager = GetComponent<InventoryManager>();
        totalPriceText.text = "0";

        Deactivate();
    }

    void OnEnable()
    {
        // Set Up UnityAction
        if (SetUpBuy == null) SetUpBuy = new UnityAction(SetUpBuyInventoryUI);
        if (SetUpSell == null) SetUpSell = new UnityAction(SetUpSellInventoryUI);
        if (SetUpFit == null) SetUpFit = new UnityAction(SetUpFitInventoryUI);

        EventManager.StartListening("SetUpBuyItems", SetUpBuy);
        EventManager.StartListening("SetUpSellItems", SetUpSell);
        EventManager.StartListening("SetUpFittingRoom", SetUpFit);
    }
    void OnDisable()
    {
        EventManager.StopListening("SetUpBuyItems", SetUpBuy);
        EventManager.StopListening("SetUpSellItems", SetUpSell);
        EventManager.StopListening("SetUpFittingRoom", SetUpFit);
    }

    private void SetUpBuyInventoryUI()
    {
        SellButton.gameObject.SetActive(false);
        FitButton.gameObject.SetActive(false);
        PurchaseButton.gameObject.SetActive(true);
        Cart.SetActive(true);
    }
    private void SetUpSellInventoryUI()
    {
        SellButton.gameObject.SetActive(true);
        FitButton.gameObject.SetActive(false);
        PurchaseButton.gameObject.SetActive(false);
        Cart.SetActive(true);
    }
    private void SetUpFitInventoryUI()
    {
        SellButton.gameObject.SetActive(false);
        FitButton.gameObject.SetActive(true);
        PurchaseButton.gameObject.SetActive(false);
        Cart.SetActive(false);
    }

    public void SetUpClothingInventory(List<Clothes> _clothingsList)
    {
        DestroyInventory();

        isTopFound = false;
        isBottomFound = false;
        isShoeFound = false;

        for (int i = 0; i < _clothingsList.Count; i++)
        {
            Clothes itemInfo = _clothingsList[i];
            GameObject newItem = Instantiate(itemGO, itemInventoryPanel.transform);
            newItem.GetComponent<ItemButton>().SetUp(itemInfo);
            SetUpOutfitSelection(itemInfo, newItem.GetComponent<ItemButton>());
        }
    }
    private void SetUpOutfitSelection(Clothes _item, ItemButton _button)
    {
        if (inventoryManager.inventoryType == InventoryManager.InventoryType.FIT)
        {
            if (isTopFound && isBottomFound && isShoeFound) return;
            else if ((_item.Type == ClothingType.TOP || _item.Type == ClothingType.DRESSES) && isTopFound) return;
            else if (_item.Type == ClothingType.BOTTOM && isBottomFound) return;
            else if (_item.Type == ClothingType.SHOES && isShoeFound) return;

            if (_item.Type == ClothingType.TOP || _item.Type == ClothingType.DRESSES)
            {
                isTopFound = isSelected(_item);
                if (isTopFound) { _button.IsSelected = isTopFound; _button.Checkmark.SetActive(isTopFound); }
            }

            if (_item.Type == ClothingType.BOTTOM)
            {
                isBottomFound = isSelected(_item);
                if (isBottomFound) { _button.IsSelected = isBottomFound; _button.Checkmark.SetActive(isBottomFound); }
            }

            if (_item.Type == ClothingType.SHOES)
            {
                isShoeFound = isSelected(_item);
                if (isShoeFound) { _button.IsSelected = isShoeFound; _button.Checkmark.SetActive(isShoeFound); }
            }

        }
    }
    private bool isSelected(Clothes _item)
    {
        if (_item.Type == ClothingType.TOP || _item.Type == ClothingType.DRESSES)
        {
            return PlayerManager.instance.player.Outfit.TopName == _item.Name;
        }
        else if (_item.Type == ClothingType.BOTTOM)
        {
            return PlayerManager.instance.player.Outfit.BottomName == _item.Name;
        }
        else if (_item.Type == ClothingType.SHOES)
        {
            return PlayerManager.instance.player.Outfit.ShoeName == _item.Name;
        }
        else return false;
    }

    public void UpdateClothingInventory(List<Clothes> _clothingsList)
    {
        ClearInventory();

        GameObject item;
        Clothes itemInfo;

        for (int i = 0; i < itemInventoryPanel.transform.childCount; i++)
        {
            item = itemInventoryPanel.transform.GetChild(i).gameObject;
            itemInfo = item.GetComponent<ItemButton>().Item;

            if (_clothingsList.Contains(itemInfo)) item.SetActive(true);
        }
    }
    public void UpdatePlayerInventory(List<Clothes> _clothingsList)
    {
        GameObject item;
        Clothes itemInfo;

        for (int i = 0; i < itemInventoryPanel.transform.childCount; i++)
        {
            item = itemInventoryPanel.transform.GetChild(i).gameObject;
            itemInfo = item.GetComponent<ItemButton>().Item;

            if (_clothingsList.Contains(itemInfo)) Destroy(item);
        }
    }
    public void UpdateInventoryUI(Clothes _item)
    {
        GameObject item;
        ItemButton itemButton;
        bool isFound = false;

        for (int i = 0; i < itemInventoryPanel.transform.childCount; i++)
        {
            item = itemInventoryPanel.transform.GetChild(i).gameObject;
            itemButton = item.GetComponent<ItemButton>();
            Debug.Log(_item.Type);

            if (itemButton.Item == _item && itemButton.IsSelected)
            {
                Debug.Log(_item.Name);
                isFound = true;
                continue;
            }
            else if (!isFound && itemButton.Item.Type == _item.Type)
            {
                Debug.Log(itemButton.Item.Name);
                itemButton.IsSelected = false;
                itemButton.Checkmark.SetActive(false);
            }

            else if (_item.Type == ClothingType.DRESSES && (itemButton.Item.Type == ClothingType.TOP || itemButton.Item.Type == ClothingType.BOTTOM))
            {
                itemButton.IsSelected = false;
                itemButton.Checkmark.SetActive(false);
            }
            else if (_item.Type == ClothingType.TOP && itemButton.Item.Type == ClothingType.DRESSES)
            {
                itemButton.IsSelected = false;
                itemButton.Checkmark.SetActive(false);
            }
            else if (_item.Type == ClothingType.BOTTOM && itemButton.Item.Type == ClothingType.DRESSES)
            {
                itemButton.IsSelected = false;
                itemButton.Checkmark.SetActive(false);
            }
        }

    }


    private void DestroyInventory()
    {
        for (int i = 0; i < itemInventoryPanel.transform.childCount; i++)
        {
            Destroy(itemInventoryPanel.transform.GetChild(i).gameObject);
        }
    }
    private void ClearInventory()
    {
        for (int i = 0; i < itemInventoryPanel.transform.childCount; i++)
        {
            itemInventoryPanel.transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    public void Deactivate()
    {
        InventoryUI.SetActive(false);
    }

    public void UpdatePlayerCurrency(int _currency)
    {
        playerCurrencyText.text = _currency.ToString();
    }

}
