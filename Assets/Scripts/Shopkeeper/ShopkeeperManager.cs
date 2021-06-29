using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopkeeperManager : MonoBehaviour
{
    public GameObject ShopkeeperDialogue;
    public GameObject ShopkeeperActions;
    public GameObject FittingRoomActions;
    public GameObject InventoryGO;

    // Dialogue
    public Text Dialogue;
    private string shoppingDialogue;
    private string fittingroomDialogue;

    void Awake()
    {
        shoppingDialogue = "Welcome to my little boutique. How can I help you?";
        fittingroomDialogue = "Would you like to use the fitting room to change?";
        Deactivate();
    }

    public void InteractWithShopKeeper()
    {
        ShopkeeperDialogue.SetActive(true);
        ShopkeeperActions.SetActive(true);
        FittingRoomActions.SetActive(false);
        Dialogue.text = shoppingDialogue;
    }
    public void InteractWithFittingRoom()
    {
        ShopkeeperDialogue.SetActive(true);
        ShopkeeperActions.SetActive(false);
        FittingRoomActions.SetActive(true);
        Dialogue.text = fittingroomDialogue;
    }

    public void BuyItems()
    {
        OpenInventory();
        EventManager.TriggerEvent("SetUpBuyItems");
    }
    public void SellItems()
    {
        OpenInventory();
        EventManager.TriggerEvent("SetUpSellItems");
    }
    public void FittingRoom()
    {
        OpenInventory();
        EventManager.TriggerEvent("SetUpFittingRoom");
    }

    private void OpenInventory()
    {
        Deactivate();
        InventoryGO.SetActive(true);
    }

    public void Deactivate()
    {
        ShopkeeperDialogue.SetActive(false);
    }
}
