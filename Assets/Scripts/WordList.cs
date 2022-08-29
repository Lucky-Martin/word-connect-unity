using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WordList : MonoBehaviour
{
    [SerializeField] GameObject wordPrefab;
    [SerializeField] GameObject letterPrefab;
    private LevelManager levelManager;

    // Start is called before the first frame update
    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
        CreateWordList();
    }

    private void CreateWordList()
    {
        string[] words = levelManager.GetCurrentLevel().words;

        for (int i = 0; i < words.Length; i++)
        {
            string word = words[i];
            GameObject wordObj = Instantiate(wordPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            wordObj.transform.SetParent(transform, false);
            wordObj.GetComponent<FillWord>().SetWord(word);

            for (int j = 0; j < word.Length; j++)
            {
                GameObject letterObj = Instantiate(letterPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                letterObj.transform.SetParent(wordObj.transform, false);
            }
        }
    }
}
