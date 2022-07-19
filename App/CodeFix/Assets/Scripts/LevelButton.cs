using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    public int index = 1;
    [SerializeField]
    private GameObject overlay;
    [SerializeField]
    private Text textUI;

    public bool isCompleted = false;

    // Start is called before the first frame update
    void Start()
    {
        // Not dynamic yet, bcs its deadline day lol
        textUI.text = index % 5 == 0 ? 5 + "" : ((index % 5)) + "";
        LevelMenu menu = FindObjectOfType<LevelMenu>();

        if(menu.completeLevel == index)
        {
            isCompleted = true;
            menu.completeLevel = -1;
        }
    }

    public void CheckLevelComplete()
    {
        if (isCompleted)
        {
            overlay.SetActive(true);
        }
    }
}
