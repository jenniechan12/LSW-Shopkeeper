using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemInventoryUI : MonoBehaviour
{
    public GameObject InventoryUI;


    // Spawning Item Buttons
    public GameObject itemInventoryPanel;
    public GameObject itemGO;

    // Shopping Cart Variables
    public Text totalPriceText;

    // Player's Currency Variables
    public Text playerCurrencyText;

    private DataManager dataManager;
    private InventoryManager inventoryManager;

    // Start is called before the first frame update
    void Start()
    {
        inventoryManager = GetComponent<InventoryManager>();
        totalPriceText.text = "0";
    }

    public void SetUpClothingInventory(List<Clothes> _clothingsList)
    {
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
