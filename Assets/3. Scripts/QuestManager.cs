using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{    
    private static QuestManager _instance;
    public static QuestManager instance
    {
        get
        {
            return _instance;
        }
    }

    public GameObject UI;
    public Text title;
    public Text description;
    private Quest curQuests;

    private void Awake()
    {
        _instance = this;
    }

    private void Update()
    {
        if  (Input.GetButtonDown("QuestUI"))
        {
            if (null != curQuests)
            {
                title.text = curQuests.title;
                description.text = curQuests.description;
            }
            else
            {
                title.text = "퀘스트 없음";
                description.text = "퀘스트 없음";
            }

            UI.SetActive(!UI.activeSelf);
        }
    } 
    public void QuestStart(Quest quest)
    {
        // 퀘스트 창에 현재 퀘스트 띄워주기
        Debug.Log("퀘스트 시작");
        Debug.Log("퀘스트 이름 : " + quest.title);
        Debug.Log("퀘스트 설명 : " + quest.description);

        curQuests = quest;        
    }

    public void QuestComplete(Quest quest)
    {
        // 보상 진행
        Debug.Log("퀘스트 완료");
        Debug.Log("퀘스트 보상 골드 : " + quest.goldReward);
        Debug.Log("퀘스트 보상 경험치 : " + quest.expReward);

        // TODO : 인베토리가 가득 찼으면 넣을 수 없게 해야함.
        InventoryManager.instance.Add(quest.itemReward); 
        curQuests = null; 
    }

    public void OnItemCollect(string itemName)
    {
        if (null == curQuests)
        {
            return; 
        } 
        if (curQuests.type != QuestType.COLLECT)
        {
            return;
        }

        Debug.Log("OnItemCollect 호출");
        curQuests.Progress();

        
    }
}
