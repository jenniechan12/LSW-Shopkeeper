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
    public GameObject InventoryUI;
    public Button PurchaseButton, SellButton;

    // Spawning Item Buttons
    public GameObject itemInventoryPanel;
    public GameObject itemGO;

    // Shopping Cart Variables
    public Text totalPriceText;

    // Player's Currency Variables
    public Text playerCurrencyText;

    // Player's Clothing Selection
    public Image playerTop, playerBottom, playerShoes;

    // Unity Actions
    private UnityAction SetUpBuy, SetUpSell;

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

        EventManager.StartListening("SetUpBuyItems", SetUpBuy);
        EventManager.StartListening("SetUpSellItems", SetUpSell);
    }
    void OnDisable()
    {
        EventManager.StopListening("SetUpBuyItems", SetUpBuy);
        EventManager.StopListening("SetUpSellItems", SetUpSell);
    }

    private void SetUpBuyInventoryUI()
    {
        SellButton.gameObject.SetActive(false);
        PurchaseButton.gameObject.SetActive(true);
    }
    private void SetUpSellInventoryUI()
    {
        SellButton.gameObject.SetActive(true);
        PurchaseButton.gameObject.SetActive(false);
    }

    public void SetUpClothingInventory(List<Clothes> _clothingsList)
    {
        DestroyInventory();

        for (int i = 0; i < _clothingsList.Count; i++)
        {
            Clothes itemInfo = _clothingsList[i];
            GameObject newItem = Instantiate(itemGO, itemInventoryPanel.transform);
            newItem.GetComponent<ItemButton>().SetUp(itemInfo);
        }
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
