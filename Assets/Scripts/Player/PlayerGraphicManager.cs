using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class PlayerGraphicManager : MonoBehaviour
{
    // SpriteRenderer for Clothes
    public SpriteRenderer topSR, bottomSR, shoeSR;

    // Animator For Clothes

    // Unity Action for UpdateClothes Event
    private UnityAction UpdateClothes;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void OnEnable()
    {
        if (UpdateClothes == null) UpdateClothes = new UnityAction(UpdatePlayerClothes);
        EventManager.StartListening("UpdatePlayerGraphics", UpdateClothes);
    }
    private void OnDisable()
    {
        EventManager.StopListening("UpdatePlayerGraphics", UpdateClothes);
    }

    private void UpdatePlayerClothes()
    {
        PlayerGraphics outfit = PlayerManager.instance.player.Outfit;
        topSR.sprite = outfit.Top;
        bottomSR.sprite = outfit.Bottom;
        shoeSR.sprite = outfit.Shoe;
    }
}
