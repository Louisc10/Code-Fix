using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeLine : MonoBehaviour
{
    private AnswerController answerController;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Answer ans = answerController.GetAnswer(collision.gameObject);
        //Debug.Log(ans.value);
        answerController.CheckAnswer(collision.gameObject, transform.gameObject);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        answerController.reset(transform.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        answerController = FindObjectOfType<AnswerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
