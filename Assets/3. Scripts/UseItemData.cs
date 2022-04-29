using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Use  Item", menuName = "Data/UseItem")]
public class UseItemData : ItemData
{
    public override void Use()
    {
        Debug.Log(name + "을 사용합니다.");
    }
}
