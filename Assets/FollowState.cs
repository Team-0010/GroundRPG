using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowState : StateMachineBehaviour
{
    Transform monsterTransform;
    Monster monster;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        monster = animator.GetComponent<Monster>();
        monsterTransform = animator.GetComponent<Transform>();      
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       monsterTransform.position = Vector2.MoveTowards(monsterTransform.position, monster.player.position, Time.deltaTime * monster.moveSpeed);
       monster.CancleAI();

       if(Vector2.Distance(monsterTransform.position , monster.player.position) > 10)
       {
           animator.SetBool("isFollow", false);
           animator.SetBool("GetReady", false);
           monster.MonsterAI();
           monster.StopMove();
       }

        if(Vector2.Distance(monsterTransform.position, monster.player.position) < 1.5f)
         animator.SetBool("isFollow", false);
         animator.SetBool("GetReady", true);

       monster.DirectionMonster(monster.player.position.x, monster.player.position.y);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
    }

}
