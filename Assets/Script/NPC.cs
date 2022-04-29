using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour, IInteractable
{
    public Conversation conversation;

    public Quest[] quests;
    public Quest[] curQuest = null;

    private void Awake()
    {
        quests = GetComponentsInChildren<Quest>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            GameObject obj = InventoryManager.instance.items[0].prefab;
            Instantiate(obj, new Vector2(0, 0), Quaternion.identity);
            InventoryManager.instance.items[0].Remove();
        }
    }

    public bool ReAction()
    {
        // 1. 가능한 퀘스트가 있으면 퀘스트 진행
        foreach (Quest quest in quests)
        {
            if (quest.isActive)
            {
                return quest.ReAction();
            }
        }

        // 2. 퀘스트가 없으면 평소 대화
        return conversation.ReAction();
    }
}
