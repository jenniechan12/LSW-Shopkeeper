using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerImageManager : MonoBehaviour
{
    public Image topImage, bottomImage, shoeImage;
    private Color color;
    private ClothingType previousType;

    void Start()
    {
        color = Color.white;
        previousType = ClothingType.NONE;
    }

    public void ChangeOutfit(Sprite _sprite, ClothingType _type)
    {
        if (_type == ClothingType.TOP) Activate(topImage, _sprite);
        else if (_type == ClothingType.BOTTOM)
        {
            Activate(bottomImage, _sprite);

            if (previousType == ClothingType.DRESSES)
            {
                Deactivate(topImage);
            }
        }
        else if (_type == ClothingType.DRESSES)
        {
            Activate(topImage, _sprite);
            Deactivate(bottomImage);
        }
        else if (_type == ClothingType.SHOES)
        {
            shoeImage.sprite = _sprite;
        }

        previousType = _type;
    }

    private void Activate(Image _image, Sprite _sprite)
    {
        color.a = 1f;
        _image.color = color;
        _image.sprite = _sprite;
    }
    private void Deactivate(Image _image)
    {
        color.a = 0f;
        _image.color = color;
        _image.sprite = null;
    }

    public Sprite[] GetOutfit()
    {
        Sprite[] outfits = new Sprite[] { topImage.sprite, bottomImage.sprite, shoeImage.sprite };
        return outfits;
    }
}
