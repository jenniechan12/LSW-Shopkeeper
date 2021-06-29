using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopkeeperManager : MonoBehaviour
{
    public GameObject ShopkeeperDialogue;
    public GameObject InventoryGO;

    void Awake()
    {
        Deactivate();
    }

    public void InteractWithShopKeeper()
    {
        ShopkeeperDialogue.SetActive(true);
    }

    public void OpenInventory()
    {
        InventoryGO.SetActive(true);
    }

    public void Deactivate()
    {
        ShopkeeperDialogue.SetActive(false);
    }
}
