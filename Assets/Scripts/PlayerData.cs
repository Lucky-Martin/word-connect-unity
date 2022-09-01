using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public static PlayerData Instance { get; set; }
    public int level;
    public int coins;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);

        level = PlayerPrefs.GetInt("level");
        if (level == 0)
        {
            level = 1;
        }

        coins = PlayerPrefs.GetInt("coins");
        if (coins == 0)
        {
            coins = 150;
        }
    }

    public void SavePlayerData()
    {
        PlayerPrefs.SetInt("level", level);
        PlayerPrefs.SetInt("coins", coins);
    }
}
