using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterShop : MonoBehaviour
{
    public void Enter()
    {
        GameManager.instance.LoadScene("ShopKeeper", "WorldMap");
    }

    public void ExitShop()
    {
        GameManager.instance.LoadScene("WorldMap", "ShopKeeper");
    }
}
