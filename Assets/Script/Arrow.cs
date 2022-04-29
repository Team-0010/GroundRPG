using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public int damage = 25;
    private void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject);
        //Destroy(other.gameObject);
        Debug.Log("타격");

    }

    private void Update()
    {
         Destroy(gameObject, 1f);
            
    }
}
