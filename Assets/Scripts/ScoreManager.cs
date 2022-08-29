using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] public GameObject starsGroup;
    [SerializeField] public Sprite filledStar;
    [SerializeField] public int minutesToCompleteLevel = 2;
    [SerializeField] public int allowedWrongGuesses = 10;
    private DateTime levelStartTimestamp;
    private int starScore = 3;
    private int wrongGuesses = 0;

    // Start is called before the first frame update
    void Start()
    {
        levelStartTimestamp = DateTime.Now;
    }

    public void ShowStars()
    {
        DateTime levelEndTimestamp = DateTime.Now;
        TimeSpan levelDuration = levelEndTimestamp - levelStartTimestamp;
        double levelDurationInMinutes = levelDuration.TotalMinutes;

        if (levelDurationInMinutes > minutesToCompleteLevel)
        {
            starScore--;
        }

        if (wrongGuesses > allowedWrongGuesses)
        {
            starScore--;
        }
        
        float delay = 0f;

        for (int i = 0; i < starScore; i++)
        {
            GameObject star = starsGroup.transform.GetChild(i).gameObject;
            Image starImageComponent = star.GetComponent<Image>();
            starImageComponent.sprite = filledStar;

            AnimateStar(star, delay);
            delay += 0.2f;
        }
    }

    public void RegisterWrongGuess()
    {
        wrongGuesses++;
    }

    private void AnimateStar(GameObject star, float delay)
    {
        star.transform.localScale = new Vector2(0, 0);
        star.transform.LeanScale(new Vector2(1, 1), 1f).setEaseOutBack().delay = delay;
    }
}
