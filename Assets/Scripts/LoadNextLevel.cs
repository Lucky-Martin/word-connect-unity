using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LoadNextLevel : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        LevelManager levelManager = FindObjectOfType<LevelManager>();
        levelManager.LoadNextLevel();
    }
}
