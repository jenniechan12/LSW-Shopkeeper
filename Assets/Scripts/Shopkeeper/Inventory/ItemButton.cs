using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemButton : MonoBehaviour
{
    // Item UI Variables
    public Clothes Item;
    public Image ItemSprite;
    public Text ItemName;
    public Text ItemPrice;
    public GameObject Checkmark;

    private bool isSelected;
    private InventoryManager inventoryManager;

    void Awake()
    {
        inventoryManager = GameObject.Find("InventoryManager").GetComponent<InventoryManager>();

        Button itemButton = GetComponent<Button>();
        itemButton.onClick.AddListener(ItemSelected);

    }

    public void SetUp(Clothes _item)
    {
        Item = _item;
        // ItemSprite.sprite = _item.Icon;
        ItemName.text = _item.Name;
        ItemPrice.text = "$" + _item.Price.ToString();
        Checkmark.SetActive(false);
    }

    public void ItemSelected()
    {
        isSelected = !isSelected;

        if (isSelected) AddItemToCart();
        else RemoveItemToCart();
    }

    private void AddItemToCart()
    {
        Checkmark.SetActive(true);
        inventoryManager.UpdateTotalPrice(Item.Price);
    }

    private void RemoveItemToCart()
    {
        Checkmark.SetActive(false);
        int price = Item.Price * -1;
        inventoryManager.UpdateTotalPrice(price);
    }

}
