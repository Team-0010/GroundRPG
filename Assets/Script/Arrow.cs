using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{   
    private void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject);
        Debug.Log("타격");
    }
}
