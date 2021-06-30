using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerImageManager : MonoBehaviour
{
    public Image topImage, bottomImage, shoeImage;
    private Color color;

    void Start()
    {
        color = Color.white;
    }

    public void ChangeOutfit(Sprite _sprite, ClothingType _type)
    {

        if (_type == ClothingType.TOP) topImage.sprite = _sprite;
        else if (_type == ClothingType.BOTTOM)
        {
            color.a = 1f;
            bottomImage.color = color;
            bottomImage.sprite = _sprite;
        }
        else if (_type == ClothingType.DRESSES)
        {
            topImage.sprite = _sprite;
            color.a = 0f;
            bottomImage.color = color;
            bottomImage.sprite = null;
        }
        else if (_type == ClothingType.SHOES)
        {
            shoeImage.sprite = _sprite;
        }
    }

    public Sprite[] GetOutfit()
    {
        Sprite[] outfits = new Sprite[] { topImage.sprite, bottomImage.sprite, shoeImage.sprite };
        return outfits;
    }
}
