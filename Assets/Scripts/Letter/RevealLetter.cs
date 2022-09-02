using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RevealLetter : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] public int hintPrice = 50;
    private PlayerData playerData;

    public void OnPointerClick(PointerEventData eventData)
    {
        playerData = FindObjectOfType<PlayerData>();

        if (playerData.coins - hintPrice < 0)
        {
            return;
        }

        FillWord[] words = FindObjectsOfType<FillWord>();

        for (int i = words.Length - 1; i >= 0; i--)
        {
            FillWord word = words[i];
            if (!word.GetWordFilled())
            {
                playerData.coins -= hintPrice;
                playerData.SavePlayerData();

                word.FillNextLetter();
                break;
            }
        }
    }
}
