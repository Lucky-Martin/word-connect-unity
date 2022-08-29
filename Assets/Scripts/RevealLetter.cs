using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RevealLetter : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        FillWord[] words = FindObjectsOfType<FillWord>();

        for (int i = words.Length - 1; i >= 0; i--)
        {
            FillWord word = words[i];
            if (!word.GetWordFilled())
            {
                word.FillNextLetter();
                break;
            }
        }
    }
}
