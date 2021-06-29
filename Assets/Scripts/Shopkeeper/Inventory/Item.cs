using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

// Clothes Database Class uses for XML 
[XmlRoot("ClothesDB"), System.Serializable]
public class ClothingsDatabase
{
    [XmlArray("Clothes"), XmlArrayItem("Cloth", typeof(Clothes))]
    public List<Clothes> ClothesDatabaseList;

    public static ClothingsDatabase Load(string path)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(ClothingsDatabase));
        using (FileStream stream = new FileStream(path, FileMode.Open))
        {
            return serializer.Deserialize(stream) as ClothingsDatabase;
        }
    }
}

// Clothes Class
[System.Serializable]
public enum ClothingType { HAT, TOP, BOTTOM, DRESSES, SHOES, ACCESSORIES, NONE };

[System.Serializable]
public class Clothes
{
    public Sprite Icon;
    public string Name;
    public string Description;
    public int Price;
    public ClothingType Type;

    public Clothes()
    {
        Icon = null;
        Name = "White Shirt";
        Description = "Hipster Shirt";
        Price = 10;
        Type = ClothingType.TOP;
    }

    public Clothes(Sprite _sprite, string _name, string _description, int _price, ClothingType _type)
    {
        Icon = _sprite;
        Name = _name;
        Description = _description;
        Price = _price;
        Type = _type;
    }

    private ClothingType GetClothingType(string _type)
    {
        switch (_type.ToUpper())
        {
            case "HAT": return ClothingType.HAT;
            case "TOP": return ClothingType.TOP;
            case "BOTTOM": return ClothingType.BOTTOM;
            case "DRESSES": return ClothingType.DRESSES;
            case "SHOES": return ClothingType.SHOES;
            case "ACCESSORIES": return ClothingType.ACCESSORIES;
            default: return ClothingType.NONE;
        }
    }
}

[System.Serializable]
public class ItemSource
{
    public string Name;
    public Sprite Sprite;
}
