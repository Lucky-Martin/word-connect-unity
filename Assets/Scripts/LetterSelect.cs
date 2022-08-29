using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LetterSelect : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] float minLetterRotation = -5f;
    [SerializeField] float maxLetterRotation = 5f;

    private WordManager wordManager;
    private string currentLetter;
    private bool buttonClicked = false;

    void Start()
    {
        wordManager = FindObjectOfType<WordManager>();

        float randomLetterRotation = Random.Range(minLetterRotation, maxLetterRotation);
        transform.Rotate(0, 0, randomLetterRotation);
    }

    public void setCurrentLetter(string word)
    {
        currentLetter = word;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (Input.GetMouseButton(0) && !buttonClicked)
        {
            wordManager.AddWordToCurrentSelection(currentLetter, transform.position);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        buttonClicked = true;
        wordManager.AddWordToCurrentSelection(currentLetter, transform.position);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        buttonClicked = false;
    }
}
