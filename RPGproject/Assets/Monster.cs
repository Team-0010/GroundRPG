using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    Rigidbody2D rigid;
    public float nextMoveX;
    public float nextMoveY;


    private void Awake() {
       rigid = GetComponent<Rigidbody2D>();

       RandomMove();
       StopMove();
    }   

    private void Update() {
       
    }

    private void FixedUpdate() {
        rigid.velocity = new Vector2(nextMoveX, nextMoveY);   
    }

    private void RandomMove(){
        nextMoveX = Random.Range(-1, 2);
        nextMoveY = Random.Range(-1, 2);
 
        Invoke("RandomMove", 2);
    }

    private void StopMove() {
        nextMoveX = 0;
        nextMoveY = 0;
        Invoke("StopMove", 4);
    }
}

