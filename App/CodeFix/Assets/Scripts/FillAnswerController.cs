using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class FillAnswerController : MonoBehaviour
{
    public FillModel[] questions; 
    private LevelMenu levelController;
    // Start is called before the first frame update

    private void Start()
    {
        levelController = FindObjectOfType<LevelMenu>();
    }

    bool flag = true;
    public void validate(){
        foreach (var item in questions)
        {
            if(String.Compare(item.gameObject.GetComponent<TMP_InputField>().text, item.value) != 0){
                flag = false;
                break;
            }
        }
        if(!flag){
            isCorrect = true ;
            labelMessage = "Sorry!! Please try again!!";
        }
        else{
            isCorrect = true;
            labelMessage = "You fix the code!!! :)" ;
        }
        OnGUI();
    }

    private string labelMessage;
    private bool isCorrect;

    private void OnGUI()
    {
        if (isCorrect)
        {
            int windowWidth = (int)(Screen.width * 0.4f);
            int windowHeight = 300;

            GUI.color = Color.white;
            GUIStyle style = GUI.skin.GetStyle("window");
            style.fixedHeight = windowHeight;

            GUI.Window(0, new Rect((Screen.width / 2) - (windowWidth / 2), (Screen.height / 2) - (windowHeight / 2), windowWidth, windowHeight), ShowGUI, "");
        }
    }

    private void ShowGUI(int windowId)
    {
        GUIStyle style = GUI.skin.GetStyle("label");
        style.fontSize = (int)(Screen.width * 0.03f);
        if (isCorrect)
        {
            GUI.Label(new Rect(25, 40, 350, 200), labelMessage, style);
        }

        style = GUI.skin.GetStyle("button");
        int x = 50;
        int width = 200;
        if ((int)(Screen.width * 0.4f) < width)
        {
            x = 20;
            width = (int)(Screen.width * 0.4f);
        }
        if (GUI.Button(new Rect(x, 200, width - (x * 2), 50), "OK", style))
        {
            isCorrect = false;
            if (flag)
            {
                levelController.CompleteLevel();
            }
        }
    }
}
