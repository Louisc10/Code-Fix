using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerController : MonoBehaviour
{
    public Answer[] questions;
    public Answer[] answers;
    // Start is called before the first frame update
    
    private Answer GetAnswer(GameObject gameObject)
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

    private Answer GetQuestion(GameObject gameObject)
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

    public void CheckAnswer(GameObject answer, GameObject question)
    {
        Answer qst = GetQuestion(question);
        int answerValue = GetAnswer(answer).value;
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

    public void validate(){
        bool flag = true;
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
