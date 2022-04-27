using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    public float moveSpeed = 1.0f;

    Rigidbody2D rigid;
    Animator anim;

    float vSpeed;
    float hSpeed;

    // 0 : 위, 1 : 오른쪽, 2 : 아래, 3: 왼쪽
    private int iDirection = 0;
    Vector2 dirVec;

    bool isActing = false;

    public int direction 
    {        
        get
        {
            return iDirection;
        }
    }

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        Move();
        Action();
    }  

    private void Move()
    {
        if (isActing)
            return;

        // 이동처리
        vSpeed = Input.GetAxisRaw("Vertical");
        hSpeed = Input.GetAxisRaw("Horizontal");
        anim.SetFloat("vSpeed", vSpeed);
        anim.SetFloat("hSpeed", hSpeed);
        Vector2 moveVec = new Vector2(hSpeed, vSpeed);
        anim.SetBool("isMove", moveVec.sqrMagnitude > 0.01f);

        // 마지막으로 보고 있었던 방향 구하기
        if (Input.GetButtonDown("Vertical"))
        {
            if (vSpeed > 0)
            {
                // 위로 눌렀을 때
                iDirection = 0;
                dirVec = Vector2.up;
            }
            else
            {
                // 아래로 눌렀을 때
                iDirection = 2;
                dirVec = Vector2.down;
            }
        }
        if (Input.GetButtonDown("Horizontal"))
        {
            if (hSpeed > 0)
            {
                // 오른쪽 눌렀을 때
                iDirection = 1;
                dirVec = Vector2.right;
            }
            else
            {
                // 왼쪽 눌렀을 때
                iDirection = 3;
                dirVec = Vector2.left;
            } 
        }
        anim.SetInteger("iDirection", iDirection);

        transform.Translate(new Vector2(hSpeed , vSpeed) * moveSpeed * Time.deltaTime);
        //rigid.velocity = new Vector2(hSpeed, vSpeed) * moveSpeed;
    }

    void Action()
    {
        Debug.DrawRay(transform.position, dirVec * 1.5f, new Color(0, 1, 0));

        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("대화신청");
            RaycastHit2D hit = Physics2D.Raycast(transform.position, dirVec, 1.5f, LayerMask.GetMask("NPC"));
            if (null != hit.collider)
            {
                Debug.Log("NPC와 접촉");
                IInteractable target = hit.collider.gameObject.GetComponent<IInteractable>();
                if (null != target)
                {
                    Debug.Log("Interactable!");
                    isActing = target.ReAction();
                    return;
                }
            }
        }
    }
}
