using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LoadNextLevel : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        StartCoroutine(TransitionNextLevel());
    }

    private IEnumerator TransitionNextLevel()
    {
        SceneLoader sceneLoader = FindObjectOfType<SceneLoader>();
        sceneLoader.FadeOut();

        yield return new WaitForSeconds(sceneLoader.transitionTime);

        LevelManager levelManager = FindObjectOfType<LevelManager>();
        levelManager.LoadNextLevel();
    }
}
