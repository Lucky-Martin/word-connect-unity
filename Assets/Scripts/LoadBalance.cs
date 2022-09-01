using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadBalance : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI balanceText;
    private PlayerData playerData;

    // Start is called before the first frame update
    void Start()
    {
        playerData = FindObjectOfType<PlayerData>();
        balanceText.text = playerData.coins.ToString();
    }
}
