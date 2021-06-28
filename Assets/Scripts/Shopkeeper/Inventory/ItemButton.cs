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

    // Start is called before the first frame update
    void Start()
    {

    }

    public void SetUp(Clothes _item)
    {
        Item = _item;
        ItemSprite.sprite = _item.Icon;
        ItemName.text = _item.Name;
        ItemPrice.text = "$" + _item.Price.ToString();
    }

    private void AddItemToCart()
    {

    }

    private void RemoveItemToCart()
    {

    }

}
