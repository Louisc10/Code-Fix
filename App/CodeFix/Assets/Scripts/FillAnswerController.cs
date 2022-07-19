using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class FillAnswerController : MonoBehaviour
{
    public FillModel[] questions;

    public void validate(){
        bool flag = true;
        foreach (var item in questions)
        {

            Debug.Log(String.Compare(item.gameObject.GetComponent<TMP_InputField>().text, item.value));
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
 
    void OnGUI()
    {
        if (isCorrect)
        {
            int windowWidth = 400;
            int windowHeight = 300;

            GUI.color = Color.white;
            GUIStyle style = GUI.skin.GetStyle ("window"); 
            style.fixedHeight = windowHeight;
            style.fontSize = 30;
            GUI.Window(0, new Rect((Screen.width / 2) - (windowWidth/2), (Screen.height / 2) - (windowHeight/2), windowWidth, windowHeight), showGUI, "", style);
        }
    }
 
    void showGUI(int windowId)
    {
        GUIStyle style = GUI.skin.GetStyle ("label"); 
        style.fontSize = 30;
        if (isCorrect)
        {
            GUI.Label(new Rect(25, 40, 350, 200), labelMessage, style);
        }
 
        style = GUI.skin.GetStyle ("button"); 
        style.fontSize = 30;
        if (GUI.Button(new Rect(50, 200, 200, 50), "OK", style))
        {
            isCorrect = false;
        }
    }
}
