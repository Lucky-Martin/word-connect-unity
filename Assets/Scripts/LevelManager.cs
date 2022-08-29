using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] public LevelData[] levels;
    [SerializeField] public int currentLevelId = 1;
    public static LevelManager Instance { get; set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public LevelData GetCurrentLevel()
    {
        return levels[currentLevelId - 1];
    }

    public void LoadNextLevel()
    {
        currentLevelId += 1;
        LoadLevel(currentLevelId);
    }

    public void EndLevel()
    {
        LevelCompletedModal levelCompletedModal = FindObjectOfType<LevelCompletedModal>();
        levelCompletedModal.OpenModal();
    }

    private void LoadLevel(int levelId)
    {
        currentLevelId = levelId;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
