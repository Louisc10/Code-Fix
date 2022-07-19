using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenu : MonoBehaviour
{
    private LevelData levelData;
    private int currLevel = -1;

    private void Awake()
    {
        levelData = SaveSystem.LoadData();

        DontDestroyOnLoad(this.gameObject);
    }

    public void Start()
    {
        LevelButton[] buttons = FindObjectsOfType<LevelButton>();

        int index = 0;

        foreach(LevelButton button in buttons)
        {
            button.isCompleted = levelData.levelsCompleted[index++];
        }
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void GoToLevel(int index)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + index);
        currLevel = index;
    }

    public void CompleteLevel()
    {
        levelData.LevelCompleted(currLevel);
        SaveSystem.SaveLevelStatus(levelData);
    }
}
