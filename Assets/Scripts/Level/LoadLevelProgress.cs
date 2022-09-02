using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadLevelProgress : MonoBehaviour
{
    private PlayerData playerData;
    private LevelManager levelManager;

    // Start is called before the first frame update
    void Start()
    {
        playerData = FindObjectOfType<PlayerData>();
        levelManager = FindObjectOfType<LevelManager>();

        levelManager.currentLevelId = playerData.level;

        TextMeshProUGUI textComponent = GetComponent<TextMeshProUGUI>();
        textComponent.text = "Level " + playerData.level.ToString() + "/" + levelManager.GetLevelCount();
    }
}
