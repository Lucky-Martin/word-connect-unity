using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Level", fileName = "New Level")]
public class LevelData : ScriptableObject
{
    public int levelId;
    public string wordString;
    public string[] words;
}
