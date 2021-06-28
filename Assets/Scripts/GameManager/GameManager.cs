using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Player player;

    void Awake()
    {
        // Make sure that GameManager exist in game
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            player = new Player();
            player.Inventory = new PlayerInventory();
            player.Outfit = new PlayerGraphics();
        }

        else if (instance != this)
            Destroy(gameObject);
    }
}
