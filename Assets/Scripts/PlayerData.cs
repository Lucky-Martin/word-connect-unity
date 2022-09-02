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
        PlayerData[] objs = GameObject.FindObjectsOfType<PlayerData>();

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        LoadPlayerData();
    }

    public void LoadPlayerData()
    {
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
