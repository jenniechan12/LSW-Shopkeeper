using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private GameObject Player;

    void Awake()
    {
        // Make sure that GameManager exist in game
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            Player = GameObject.FindWithTag("Player");
        }

        else if (instance != this)
            Destroy(gameObject);
    }

    public void LoadScene(string _sceneName, string _prevScene)
    {
        SceneManager.LoadScene(_sceneName);

        if (_sceneName == "WorldMap" && _prevScene == "TitleScene")
        {
            Player.transform.position = Vector3.zero;
        }
        else if (_sceneName == "WorldMap" && _prevScene == "ShopKeeper")
        {
            Player.transform.position = new Vector3(3, 7, 0);
        }
        else if (_sceneName == "ShopKeeper" && _prevScene == "WorldMap")
        {
            Player.transform.position = new Vector3(0, -4, 0);
        }
    }
}
