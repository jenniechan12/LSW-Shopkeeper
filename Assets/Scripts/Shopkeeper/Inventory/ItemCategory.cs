using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCategory : MonoBehaviour
{
    private InventoryManager inventoryManager;

    void Awake()
    {
        inventoryManager = GameObject.Find("InventoryManager").GetComponent<InventoryManager>();
    }

    public void ShowAll()
    {
        inventoryManager.UpdateInventory(ClothingType.NONE);
    }
    public void ShowHat()
    {
        inventoryManager.UpdateInventory(ClothingType.HAT);
    }
    public void ShowTop()
    {
        inventoryManager.UpdateInventory(ClothingType.TOP);
    }
    public void ShowBottom()
    {
        inventoryManager.UpdateInventory(ClothingType.BOTTOM);
    }
    public void ShowDresses()
    {
        inventoryManager.UpdateInventory(ClothingType.DRESSES);
    }
    public void ShowShoes()
    {
        inventoryManager.UpdateInventory(ClothingType.SHOES);
    }
}
