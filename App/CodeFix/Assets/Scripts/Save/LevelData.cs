using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelData
{
    public bool[] levelsCompleted;

    public LevelData(bool[] levelsCompleted)
    {
        this.levelsCompleted = levelsCompleted;
    }

    public void SaveData(bool[] levelsData)
    {
        levelsCompleted = levelsData;
    }

    public void LevelCompleted(int index)
    {
        levelsCompleted[index-1] = true;
    }
}
