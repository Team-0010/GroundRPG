using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Conversation : MonoBehaviour, IInteractable
{
    GameManager manager;

    [SerializeField]
    private string Title; 

    [TextArea]
    public string[] conversation;

    int converIndex = 0;


    private void Awake()
    {
        //if (null == GetComponentInParent<GameObject>())
        //{
        //    Title = GetComponentInParent<GameObject>().name;
        //}
    }

    private void Start()
    {
        manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    public bool ReAction()
    {
        Debug.Log("리액션 진입");
        if (converIndex < conversation.Length)
        {
            Debug.Log("대화 시도");
            manager.SetActiveDialog(true);
            manager.SetDialogContent(Title, conversation[converIndex]);
            converIndex++;
            return true;
        }
        else
        {
            manager.SetActiveDialog(false);
            converIndex = 0;
            return false;
        }




    }
}
