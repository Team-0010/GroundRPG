using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    private static InventoryManager _instance;
    
    public static InventoryManager instance
    {
        get
        {
            return _instance;
        }
    }

    public InventoryUI UI;
    public List<ItemData> items = new List<ItemData>();
    public int maxSize = 20;

    private void Awake()
    {
        _instance = this;
    }

    private void Update()
    {
        if (Input.GetButtonDown("InventoryUI"))
        {
            UI.gameObject.SetActive(!UI.gameObject.activeSelf);
            UI.UpdateUI();
        }
    }
    public bool Add(ItemData item)
    {
        if (items.Count >= maxSize)
        {
            return false;
        }
        items.Add(item);
        UI.UpdateUI();
        return true;
    }

    public void Remove(ItemData item )
    {
        items.Remove(item);
        UI.UpdateUI();
    }
}
