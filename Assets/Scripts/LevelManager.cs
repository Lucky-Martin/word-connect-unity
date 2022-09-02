using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] public TextAsset levelJSON;
    [SerializeField] public int currentLevelId;
    public static LevelManager Instance { get; set; }
    private LevelData[] levels;
    private PlayerData playerData;

    private void Awake()
    {
        LevelManager[] objs = FindObjectsOfType<LevelManager>();

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);

        playerData = FindObjectOfType<PlayerData>();
        currentLevelId = playerData.level;
    }

    // Start is called before the first frame update
    void Start()
    {
        LoadLevelsFromJson();
    }

    public int GetLevelCount()
    {
        return levels.Length;
    }

    public LevelData GetCurrentLevel()
    {
        if (levels == null)
        {
            LoadLevelsFromJson();
        }

        if (playerData.level == 0)
        {
            playerData.LoadPlayerData();
        }

        currentLevelId = playerData.level;

        return levels[currentLevelId - 1];
    }

    public void LoadNextLevel()
    {
        currentLevelId += 1;
        playerData.level += 1;
        playerData.SavePlayerData();

        LoadLevel(currentLevelId);
    }

    public void EndLevel()
    {
        LevelCompletedModal levelCompletedModal = FindObjectOfType<LevelCompletedModal>();
        levelCompletedModal.OpenModal();
    }

    private void LoadLevelsFromJson()
    {
        levels = JsonUtility.FromJson<LevelList>(levelJSON.text).levels;
    }

    private void LoadLevel(int levelId)
    {
        currentLevelId = levelId;
        Debug.Log("Load level with id: " + levelId);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
