using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    public List<Clothes> ClothingsDatabase;
    public List<ItemSource> ClothingsSourceList;

    private List<Clothes> starterPack;
    private GameObject Player;

    void Awake()
    {
        // Make sure that DataManager exist in game
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            Player = GameObject.FindWithTag("Player");

            LoadClothesFile();
            CreateStarterPack();
            LoadPlayerDataFile();
        }

        else if (instance != this)
            Destroy(gameObject);
    }


    public void LoadPlayerDataFile()
    {
        Player player = new Player();

        string path = Path.Combine(Application.persistentDataPath, "PlayerData.dat");
        if (File.Exists(path))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(path, FileMode.Open);
            player = (Player)bf.Deserialize(file);

            file.Close();
        }

        else
        {
            player = CreateDefaultPlayer();
            // SavePlayerDataFile();
        }

        PlayerManager.instance.player = player;
        EventManager.TriggerEvent("UpdatePlayerGraphics");
    }
    public void SavePlayerDataFile()
    {
        string path = Path.Combine(Application.persistentDataPath, "Player.dat");
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(path);

        Player player = PlayerManager.instance.player;
        bf.Serialize(file, player);
        file.Close();
    }

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
        starterPack.Add(new Clothes(GetSpriteIcon("White Shirt"), "White Shirt", "", 100, ClothingType.TOP));
        starterPack.Add(new Clothes(GetSpriteIcon("Blue Jean"), "Blue Jean", "", 150, ClothingType.BOTTOM));
        starterPack.Add(new Clothes(GetSpriteIcon("White Shoe"), "White Shoe", "", 75, ClothingType.SHOES));
    }
    private Player CreateDefaultPlayer()
    {
        Player newPlayer = new Player();
        newPlayer.Inventory = new PlayerInventory();
        newPlayer.Outfit = new PlayerGraphics();
        newPlayer.Inventory.Currency = 10000;
        newPlayer.Inventory.ClothingsBag = new List<Clothes>(starterPack);
        newPlayer.Outfit.StarterPack(GetSprite("White Shirt"), GetSprite("Blue Jean"), GetSprite("White Shoe"));

        return newPlayer;
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
