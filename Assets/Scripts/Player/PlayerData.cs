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
        InitPlayer();
    }

    public void InitPlayer()
    {
        if (PlayerPrefs.GetInt("init") == 0)
        {
            level = 1;
            coins = 150;
            SavePlayerData();

            PlayerPrefs.SetInt("init", 1);
        }
        else
        {
            level = PlayerPrefs.GetInt("level");
            coins = PlayerPrefs.GetInt("coins");
        }
    }

    public void SavePlayerData()
    {
        PlayerPrefs.SetInt("level", level);
        PlayerPrefs.SetInt("coins", coins);
    }
}
