using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenu : MonoBehaviour
{
    private LevelData levelData;
    private int currLevel = -1;
    private LevelButton[] buttons;

    [HideInInspector]
    public int completeLevel = -1;

    private void Awake()
    {
        levelData = SaveSystem.LoadData();

        DontDestroyOnLoad(gameObject);
    }

    public void Start()
    {
        buttons = FindObjectsOfType<LevelButton>();

        foreach(LevelButton button in buttons)
        {
            button.isCompleted = levelData.levelsCompleted[button.index-1];
            button.CheckLevelComplete();
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

        completeLevel = currLevel;

        SceneManager.LoadScene(1);
    }
}
