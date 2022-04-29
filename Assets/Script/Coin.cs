using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Coin : MonoBehaviour
{
    public static UnityAction OnGlodCollected;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("코인 먹음");
        OnGlodCollected?.Invoke();
        Destroy(gameObject);
    }
}
