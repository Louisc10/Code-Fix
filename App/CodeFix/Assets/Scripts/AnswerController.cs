using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerController : MonoBehaviour
{
    public Answer[] questions;
    public Answer[] answers;
    // Start is called before the first frame update
    
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
}
