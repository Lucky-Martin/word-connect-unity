using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CreateLetters : MonoBehaviour
{
    [SerializeField] public GameObject buttonPrefab;
    private LevelManager levelManager;

    // Start is called before the first frame update
    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();

        SetupLetters(transform.GetChild(0));
    }

    private void SetupLetters(Transform buttonGroup)
    {
        string wordString = levelManager.GetCurrentLevel().wordString;

        for (int i = 0; i < wordString.Length; i++)
        {
            string currentLetter = wordString[i].ToString();
            GameObject wordButtonObj = Instantiate(buttonPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            wordButtonObj.transform.SetParent(buttonGroup.transform, false);

            TextMeshProUGUI buttonText = wordButtonObj.GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = currentLetter;

            LetterSelect wordButtonHoverSelect = wordButtonObj.GetComponent<LetterSelect>();
            wordButtonHoverSelect.setCurrentLetter(currentLetter);
        }
    }
}
