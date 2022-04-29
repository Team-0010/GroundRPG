using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadyState : StateMachineBehaviour
{
    Monster monster;
    Transform monsterTransform;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       monster = animator.GetComponent<Monster>();
       monsterTransform = animator.GetComponent<Transform>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
       if((monster.attackDelay <= 0) && Vector2.Distance(monsterTransform.position, monster.player.position) < 2f)
        {
            animator.SetBool("isFollow",false);
            animator.SetTrigger("Attack");
        }

       if(Vector2.Distance(monster.player.position, monsterTransform.position) > 2f && Vector2.Distance(monster.player.position, monsterTransform.position) < 10){
        animator.SetBool("isFollow", true);           
        animator.SetBool("GetReady", false);
       }


       monster.DirectionMonster(monster.player.position.x , monsterTransform.position.x);
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
    }

}
