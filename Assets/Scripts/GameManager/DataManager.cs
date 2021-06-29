using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    public List<Clothes> ClothingsDatabase;
    public List<ItemSource> ClothingsSourceList;

    void Awake()
    {
        // Make sure that DataManager exist in game
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            LoadClothesFile();

        }

        else if (instance != this)
            Destroy(gameObject);
    }

    // Start is called before the first frame update

    void LoadClothesFile()
    {
        ClothingsDatabase = new List<Clothes>();
        ClothingsDatabase.Add(new Clothes(GetSprite("Blue Top"), "Blue Top", "", 250, ClothingType.TOP));
        ClothingsDatabase.Add(new Clothes(GetSprite("Bunny T-shirt"), "Bunny T-shirt", "", 250, ClothingType.TOP));
        ClothingsDatabase.Add(new Clothes(GetSprite("Wavy Skirt"), "Wavy Skirt", "", 450, ClothingType.BOTTOM));
        ClothingsDatabase.Add(new Clothes(GetSprite("Miniskirt"), "Miniskirt", "", 1000, ClothingType.BOTTOM));
        ClothingsDatabase.Add(new Clothes(GetSprite("Sandal"), "Sandal", "", 1000, ClothingType.SHOES));
        ClothingsDatabase.Add(new Clothes(GetSprite("Sneaker"), "Sneaker", "", 120, ClothingType.SHOES));

    }

    private Sprite GetSprite(string _key)
    {
        ItemSource source = ClothingsSourceList.Find(x => x.Name == _key);
        if (source != null) return source.Sprite;
        else return null;
    }

    // void LoadClothesFile()
    // {
    //     string path = Path.Combine(Application.streamingAssetsPath, "XML/ClothingDatabase.xml");

    //     Debug.Log(path);

    //     if (File.Exists(path))
    //     {
    //         clothingsDatabase = ClothingsDatabase.Load(path);
    //         Debug.Log(clothingsDatabase.ClothesDatabaseList.Count);
    //     }
    // }
}
