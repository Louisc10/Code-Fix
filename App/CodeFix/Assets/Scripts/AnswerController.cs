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
            Debug.Log(item.gameObject.transform.position);
            Debug.Log(item.value);
            if(!item.isCorrect){
                flag = false;
                break;
            }
        }
        if(!flag){
            Debug.Log("Masih ada yang salah");
        }
        else{
            Debug.Log("Sudah bener semua");
        }
    }

    public void reset(GameObject question)
    {
        GetQuestion(question).isCorrect = false;
    }
}
