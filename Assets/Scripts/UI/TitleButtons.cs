using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleButtons : MonoBehaviour
{

    public void PlayGame()
    {
        GameManager.instance.LoadScene("WorldMap", "TitleScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
