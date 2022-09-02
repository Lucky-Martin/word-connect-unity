using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCompletedModal : MonoBehaviour
{
    [SerializeField] public float backgroundTransparency = 0.5f;
    [SerializeField] public float duration = 1.5f;
    [SerializeField] public Transform box;
    [SerializeField] public CanvasGroup background;
    private ScoreManager scoreManager;

    private void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    public void OpenModal()
    {
        //enable the modal
        transform.GetChild(0).gameObject.SetActive(true);

        scoreManager.ShowStars();

        background.alpha = 0;
        background.LeanAlpha(backgroundTransparency, duration);

        box.localPosition = new Vector3(0, -Screen.height);
        box.LeanMoveLocalY(0, duration).setEaseOutExpo().delay = 0.1f;
    }
}
