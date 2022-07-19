using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerController : MonoBehaviour
{
    public DndModel[] questions;
    public DndModel[] answers;
    private LevelMenu levelController;
    // Start is called before the first frame update

    private void Awake()
    {
        levelController = FindObjectOfType<LevelMenu>();
    }

    private DndModel GetAnswer(GameObject gameObject)
    {
        for(int i = 0; i < answers.Length; i++)
        {
            if(answers[i].gameObject == gameObject)
            {
                return answers[i];
            }
        }
        return null;
    }

    private DndModel GetQuestion(GameObject gameObject)
    {
        for (int i = 0; i < questions.Length; i++)
        {
            if (questions[i].gameObject == gameObject)
            {
                return questions[i];
            }
        }
        return null;
    }

    public void CheckAnswer(GameObject DndModel, GameObject question)
    {
        DndModel qst = GetQuestion(question);
        int answerValue = GetAnswer(DndModel).value;
        int questionValue = qst.value;

        if(answerValue == questionValue)
        {
            qst.isCorrect = true;
        }
        else
        {
            qst.isCorrect = false;
        }
    }

    bool flag = true;
    public void validate(){
        foreach (var item in questions)
        {
            if(!item.isCorrect){
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

    public void reset(GameObject question)
    {
        GetQuestion(question).isCorrect = false;
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
            
            GUI.Window(0, new Rect((Screen.width / 2) - (windowWidth/2), (Screen.height / 2) - (windowHeight/2), windowWidth, windowHeight), ShowGUI, "");
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
            if(flag)
            {
                levelController.CompleteLevel();
            }
        }
    }
}
