using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WordManager : MonoBehaviour
{
    private LevelManager levelManager;
    private LevelData currentLevel;
    private ScoreManager scoreManager;
    private LineDrawer lineDrawer;
    private string[] words;
    private string currentSelection = "";
    private int guessedWords = 0;

    // Start is called before the first frame update
    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
        scoreManager = FindObjectOfType<ScoreManager>();
        lineDrawer = FindObjectOfType<LineDrawer>();

        currentLevel = levelManager.GetCurrentLevel();

        words = currentLevel.words;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0) && currentSelection != "")
        {
            CheckSelectionForMatch();
            lineDrawer.DestroyLine();
        }
    }

    public void AddWordToCurrentSelection(string word, Vector2 buttonPos)
    {
        currentSelection += word;
        
        if (currentSelection.Length == currentLevel.wordString.Length)
        {
            CheckSelectionForMatch();
            lineDrawer.DestroyLine();
        }
        else
        {
            lineDrawer.StartLineRender(true, buttonPos);
        }
    }

    public void AddGuessedWord(string word)
    {
        guessedWords++;
        Debug.Log("Word found: " + word);
    }

    public void CheckSelectionForMatch()
    {
        if (Array.IndexOf(words, currentSelection) != -1)
        {
            AddGuessedWord(currentSelection);
            FillWordLetters(currentSelection);

            if (guessedWords == words.Length)
            {
                levelManager.EndLevel();
            }
        }
        else
        {
            Debug.Log("Word not found: " + currentSelection);
            scoreManager.RegisterWrongGuess();
        }

        currentSelection = "";
    }

    private void FillWordLetters(string word)
    {
        FillWord[] fillWords = FindObjectsOfType<FillWord>();

        for (int i = 0; i < words.Length; i++)
        {
            FillWord fillWord = fillWords[i];
            if (fillWord.GetWord() == word)
            {
                fillWord.FillLetters();
            }
        }
    }
}
