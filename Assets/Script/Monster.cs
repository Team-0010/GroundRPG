using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour, IMonster
{
    Rigidbody2D rigid;
    Animator animator;
    SpriteRenderer render;
    public int nextMoveX;
    public int nextMoveY;
    public float moveSpeed;
    public Transform player; // 플레이어 좌표 저장용 변수
    public Transform Attackboxpos;
    public Vector2 AttackboxSize;

    public float attackCooltime = 3f;
    public float attackDelay;
    public Vector2 monsterDir;
    
    private int health = 50;
    private int AttackDamage = 10;

    public GameObject dropItem;

    private void Awake() {
       rigid = GetComponent<Rigidbody2D>();
       animator = GetComponent<Animator>();
       render = GetComponent<SpriteRenderer>();

       MonsterAI();
       StopMove();

        player = GameObject.FindGameObjectWithTag("Player").transform;
    }   

    private void Update() {
        CheckDir();        
       if(attackDelay >= 0)
        attackDelay -= Time.deltaTime;
        Debug.DrawRay(transform.position, monsterDir * 3f,Color.red );
    }

    private void FixedUpdate() {
        rigid.velocity = new Vector2(nextMoveX, nextMoveY);  

    }

    public void MonsterAI(){
        nextMoveX = Random.Range(-1, 2);
        nextMoveY = Random.Range(-1, 2);
        
        animator.SetInteger("nextMoveX", nextMoveX);

        if(nextMoveX != 0) {
            render.flipX = nextMoveX == -1;
        }

        Invoke("MonsterAI", 2);
    }

    public void StopMove() {
        nextMoveX = 0;
        nextMoveY = 0;
        Invoke("StopMove", 4);
    }

    public void CancleAI(){
        CancelInvoke("MonsterAI");
        CancelInvoke("StopMove");
    }

    public void DirectionMonster(float target, float baseobj)
    {
        if(target < baseobj)
        {
            animator.SetFloat("Direction", -1);
            render.flipX = true;
        }         
        else {
            animator.SetFloat("Direction", 1);
            render.flipX = false;
        }
        
    }

    private void CheckRay()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, monsterDir, 3f, LayerMask.GetMask("Monster") | LayerMask.GetMask("Ground"));

        if( hit == true)
        {   
            nextMoveX *= -1;
            nextMoveY *= -1;
            CancelInvoke("MonsterAI");
            Invoke("MosterAI", 3);
        }
    }

    private void CheckDir()
    {
        if(nextMoveX == 1)
        monsterDir = Vector2.right;
        
        else if(nextMoveX == -1)
        monsterDir = Vector2.left;

        else if(nextMoveY == 1)
        monsterDir = Vector2.up;

        else if(nextMoveY == -1)
        monsterDir = Vector2.down;
    }

    private void DropItem()
    {
        Instantiate(dropItem, gameObject.transform.position, Quaternion.identity);
    }

    // 충돌처리
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Arrow")
        {
            Hitted(other.gameObject.GetComponent<Arrow>().damage);
            Debug.Log("충돌 발생");
        }
    }

   public void Hitted(int damage)
    {
        health -= damage;
        if(health <= 0)
        Die();
    }

    public void Attack(Player playerStat)
    {
        playerStat.health -= AttackDamage;
    }

    public void Die()
    {
        animator.SetTrigger("Die");
        CancelInvoke("MonsterAI");  
        Invoke("DropItem", 1f);
        Destroy(gameObject, 1f);
    }
}

