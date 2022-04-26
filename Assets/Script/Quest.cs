using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum QuestType
{
    COLLECT,
    KILL,
    ESCORT,
    DEVIVERY,

    SIZE,
}

public class Quest : MonoBehaviour
{
    public UnityAction<Quest> OnStart;
    public UnityAction<Quest> OnComplete;

    public bool isActive;  // 퀘스트가 가능한 상황
    public bool isStart = false;  // 퀘스트가 수락됐을 때
    public bool isFinish = false;  // 퀘스트가 완료됐을 때
    public QuestType type;
    public Coin requirement;
    public string title;
    [TextArea]
    public string description;    
    public int curAmount;
    public int requireAmount;
    public ItemData itemReward;
    public int expReward;
    public int goldReward;

    public Conversation accept, progress, complete;
    public Quest[] nextQuest;


    private void Start()
    {
        OnStart += QuestManager.instance.QuestStart;
        OnComplete += QuestManager.instance.QuestComplete;
        Coin.OnGlodCollected += Progress;
    }


    public void Accept()
    {
        OnStart?.Invoke(this);
        isStart = true;
        Debug.Log(title + " 가 수락되었습니다.");
    }

    public void Progress()
    {
        Debug.Log("골드 + 1");
        curAmount++;
        Debug.Log(title + " 가 진행 중입니다. - " + curAmount + "/" + requireAmount);
    }

    public void Complete()
    {
        OnComplete?.Invoke(this);
        isActive = false;
        foreach(Quest quest in nextQuest)
        {
            quest.isActive = true;
        }
        Debug.Log(title + " 가 완료되었습니다.");
    }

    public bool ReAction()
    {
        if (!isStart) // 수락 전
        {
            bool reAction = accept.ReAction();
            if (reAction)
            {
                return true;
            }
            else
            {
                Accept();
                return false;
            }
        }
        else if (!isFinish) // 진행 중
        {           
            if (curAmount < requireAmount)
            {
                Debug.Log("퀘스트 진행 중 진입");
                return progress.ReAction();
            }
            else
            {
                isFinish = true;
                return ReAction();
            }
        }
        else  // 완료 시 
        {
            bool reAction = complete.ReAction();
            if (reAction)
            {
                return true;
            }
            else
            {
                Complete();
                return false;
            }
        }
    }
}
