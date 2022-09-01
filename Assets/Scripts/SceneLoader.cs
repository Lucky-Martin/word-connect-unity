using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] public Animator transition;
    [SerializeField] public float transitionTime = 1f;

    public void FadeOut(bool loadGameScene = false)
    {
        StartCoroutine(LoadGame(loadGameScene));
    }

    private IEnumerator LoadGame(bool loadGameScene)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        if (loadGameScene)
        {
            SceneManager.LoadScene(1);
        }
    }
}
