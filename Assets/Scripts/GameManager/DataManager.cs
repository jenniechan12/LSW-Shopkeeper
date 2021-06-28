using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    public List<Clothes> ClothingsDatabase;

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
        ClothingsDatabase.Add(new Clothes("Shirt", "", 250, ClothingType.TOP));
        ClothingsDatabase.Add(new Clothes("Pant", "", 450, ClothingType.BOTTOM));
        ClothingsDatabase.Add(new Clothes("Dress", "", 1000, ClothingType.DRESSES));
        ClothingsDatabase.Add(new Clothes("Sneaker", "", 120, ClothingType.SHOES));
        ClothingsDatabase.Add(new Clothes("Blue Shirt", "", 250, ClothingType.TOP));

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
