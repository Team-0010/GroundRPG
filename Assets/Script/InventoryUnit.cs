using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUnit : MonoBehaviour
{
    public Button button;
    public Image icon;
    ItemData curItemData;

    public void AddItem(ItemData itemData)
    {
        curItemData = itemData;
        icon.sprite = itemData.icon;
        icon.enabled = true;
        button.interactable = true;

    }

    public void RemoveItem()
    {
        curItemData = null;
        icon.sprite = null;
        icon.enabled = false;
        button.interactable = false;
    }

    public void UseItem()
    {
        Debug.Log(curItemData.name + "가 사용되었습니다.");
        curItemData.Use(); 
    }
}
