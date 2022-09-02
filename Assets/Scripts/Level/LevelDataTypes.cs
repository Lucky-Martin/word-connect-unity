using System;

[System.Serializable]
public class LevelData
{
    public int levelId;
    public string wordString;
    public string[] words;
}

[System.Serializable]
public class LevelList
{
    public LevelData[] levels;
}