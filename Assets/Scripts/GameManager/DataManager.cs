using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    public List<Clothes> ClothingsDatabase;
    public List<ItemSource> ClothingsSourceList;

    private List<Clothes> starterPack;

    void Awake()
    {
        // Make sure that DataManager exist in game
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            LoadClothesFile();
            CreateStarterPack();
        }

        else if (instance != this)
            Destroy(gameObject);
    }

    // Start is called before the first frame update

    void LoadClothesFile()
    {
        ClothingsDatabase = new List<Clothes>();
        ClothingsDatabase.Add(new Clothes(GetSpriteIcon("Blue Top"), "Blue Top", "", 250, ClothingType.TOP));
        ClothingsDatabase.Add(new Clothes(GetSpriteIcon("Bunny T-shirt"), "Bunny T-shirt", "", 250, ClothingType.TOP));
        ClothingsDatabase.Add(new Clothes(GetSpriteIcon("Wavy Skirt"), "Wavy Skirt", "", 450, ClothingType.BOTTOM));
        ClothingsDatabase.Add(new Clothes(GetSpriteIcon("Miniskirt"), "Miniskirt", "", 1000, ClothingType.BOTTOM));
        ClothingsDatabase.Add(new Clothes(GetSpriteIcon("Pink Uniform"), "Pink Uniform", "", 2500, ClothingType.DRESSES));
        ClothingsDatabase.Add(new Clothes(GetSpriteIcon("Sandal"), "Sandal", "", 1000, ClothingType.SHOES));
        ClothingsDatabase.Add(new Clothes(GetSpriteIcon("Sneaker"), "Sneaker", "", 120, ClothingType.SHOES));

    }

    private Sprite GetSpriteIcon(string _key)
    {
        ItemSource source = ClothingsSourceList.Find(x => x.Name == _key);
        if (source != null) return source.Icon;
        else return null;
    }
    public Sprite GetSprite(string _key)
    {
        ItemSource source = ClothingsSourceList.Find(x => x.Name == _key);
        if (source != null) return source.Sprite;
        else return null;
    }

    private void CreateStarterPack()
    {
        starterPack = new List<Clothes>();
        starterPack.Add(new Clothes(GetSpriteIcon("White Tee"), "White Tee", "", 100, ClothingType.TOP));
        starterPack.Add(new Clothes(GetSpriteIcon("Blue Jean"), "Blue Jean", "", 150, ClothingType.BOTTOM));
        starterPack.Add(new Clothes(GetSpriteIcon("White Shoe"), "White Shoe", "", 75, ClothingType.SHOES));
    }

    private void CreateDefaultPlayer(string _name)
    {
        Player newPlayer = new Player(_name);
        newPlayer.Inventory.Currency = 10000;
        newPlayer.Inventory.ClothingsBag = new List<Clothes>(starterPack);
        newPlayer.Outfit.StarterPack(GetSprite("White Tee"), GetSprite("Blue Jean"), GetSprite("White Shoe"));


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
