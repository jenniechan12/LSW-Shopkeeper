using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
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
    public bool IsSelected
    {
        get { return isSelected; }
        set { isSelected = value; }
    }
    private InventoryManager inventoryManager;

    // Unity Actions
    private UnityAction ResetButton;

    void Awake()
    {
        inventoryManager = GameObject.Find("InventoryManager").GetComponent<InventoryManager>();

        Button itemButton = GetComponent<Button>();
        itemButton.onClick.AddListener(ItemSelected);

        ResetButton = new UnityAction(ResetSelect);
    }

    void OnEnable()
    {
        EventManager.StartListening("ResetCart", ResetButton);
    }
    void OnDisable()
    {
        EventManager.StopListening("ResetCart", ResetButton);
    }

    public void SetUp(Clothes _item)
    {
        Item = _item;
        ItemSprite.sprite = _item.Icon;
        ItemName.text = _item.Name;
        ItemPrice.text = "$" + _item.Price.ToString();
        Checkmark.SetActive(false);
    }

    public void ItemSelected()
    {
        // Handle for Buying/Selling 
        if (inventoryManager.inventoryType != InventoryManager.InventoryType.FIT)
        {
            isSelected = !isSelected;

            if (isSelected) AddItemToCart();
            else RemoveItemToCart();
        }

        // Handle Fitting Room
        else
        {
            isSelected = true;
            UpdateOutfit();
        }

    }
    private void UpdateOutfit()
    {
        Checkmark.SetActive(true);
        inventoryManager.UpdateOutfit(Item);
    }
    private void AddItemToCart()
    {
        Checkmark.SetActive(true);
        inventoryManager.AddItemToCart(Item);
        inventoryManager.UpdateTotalPrice(Item.Price);
    }
    private void RemoveItemToCart()
    {
        Checkmark.SetActive(false);
        int price = Item.Price * -1;
        inventoryManager.RemoveItemFromCart(Item);
        inventoryManager.UpdateTotalPrice(price);
    }
    private void ResetSelect()
    {
        isSelected = false;
        Checkmark.SetActive(false);
    }
}
