using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FillWord : MonoBehaviour
{
    [SerializeField] ParticleSystem wordGuessedParticles;
    private WordManager wordManager;
    private string word;
    private bool wordFilled = false;

    private void Start()
    {
        wordManager = FindObjectOfType<WordManager>(); 
    }

    private void PlayParticles()
    {
        ParticleSystem particles = Instantiate(wordGuessedParticles, new Vector3(0, transform.position.y, 0), Quaternion.identity);
        particles.Play();
    }

    public void SetWord(string wordStr)
    {
        word = wordStr;
    }

    public string GetWord()
    {
        return word;
    }

    public bool GetWordFilled()
    {
        return wordFilled;
    }    

    public void FillLetters()
    {
        int letterIndex = 0;

        foreach (Transform letter in transform)
        {
            TextMeshProUGUI letterTextObj = letter.GetComponentInChildren<TextMeshProUGUI>();
            letterTextObj.text = word[letterIndex].ToString();

            letterIndex++;
        }

        wordFilled = true;
        PlayParticles();
    }

    public void FillNextLetter()
    {
        int letterIndex = 0;

        foreach (Transform letter in transform)
        {
            TextMeshProUGUI letterTextObj = letter.GetComponentInChildren<TextMeshProUGUI>();

            if (letterTextObj.text == "")
            {
                letterTextObj.text = word[letterIndex].ToString();

                if (letterIndex == word.Length - 1)
                {
                    wordFilled = true;
                    wordManager.AddGuessedWord(word);
                    PlayParticles();
                }

                break;
            }
            
            letterIndex++;
        }
    }
}
