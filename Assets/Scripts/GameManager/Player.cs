using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public string Name;
    public PlayerGraphics Outfit;
    public PlayerInventory Invnentory;


    void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

}

public class PlayerGraphics
{
    public Sprite Hat;
    public Sprite Top;
    public Sprite Bottom;
    public Sprite Dresses;
    public Sprite Shoe;
}

public class PlayerInventory
{
    public int Currency;
    public List<Clothes> ClothingsBag;
}
