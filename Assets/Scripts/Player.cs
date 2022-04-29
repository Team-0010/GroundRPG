using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float playerSpeed;

    Rigidbody2D rigid;

    public int damage = 50;
    public int health = 50;
    private void Awake() {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        Move();
    }

    private void Move(){
        float hMove = Input.GetAxis("Horizontal");
        float vMove = Input.GetAxis("Vertical");

        float hSpeed = hMove * playerSpeed * Time.deltaTime;
        float vSpeed = vMove * playerSpeed * Time.deltaTime;

        Vector2 vec = new Vector2(hSpeed, vSpeed);
        rigid.velocity = vec;
    }

}
