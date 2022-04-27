using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject arrow;
    public GameObject player;

    float coolTime = 100;
    bool isAttack = false;
    Animator playerAnim;

    public bool isAttacking
    {
        get { return isAttack; }
        set { isAttack = value; }
    }

    private void Awake()
    {
        playerAnim = player.GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown("space") && !isAttack)
        {
            isAttack = true;
            coolTime = 100f;
            Debug.Log("Attack On");
            Debug.Log(coolTime);
        }

        if (isAttack)
        {
            AttackCoolTime();
        }

        playerAnim.SetBool("isAttack", isAttack);
    }

    void AttackCoolTime()
    {
        coolTime -= 1;
        if (coolTime < 0)
        {
            coolTime = -1;
            isAttack = false;
            Debug.Log("Attack Off");
            Debug.Log(coolTime);
        }
    }
}
