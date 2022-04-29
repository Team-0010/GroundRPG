using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : StateMachineBehaviour
{
    Transform monsterTransform;
    Monster monster;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       monster = animator.GetComponent<Monster>();
       monsterTransform = animator.GetComponent<Transform>();
    }

     override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       if(Vector2.Distance(monsterTransform.position, monster.player.position) <= 10) // 플레이어와 몬스터의 거리가 10 이하일때
       {
           animator.SetBool("isFollow", true);
       }

  
    }

     override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
    }

}
