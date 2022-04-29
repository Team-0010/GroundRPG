using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public abstract class ItemData : ScriptableObject
{
    new public string name = "New Item";
    public Sprite icon = null;
    public GameObject prefab = null;

    public abstract void Use();
    public void Remove()
    {
        // TODO : 인벤토리 창에서 지우는 작업
    }
}
