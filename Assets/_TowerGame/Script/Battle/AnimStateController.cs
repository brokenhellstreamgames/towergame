﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimStateController : StateMachineBehaviour
{
    [SerializeField] private bool hasResetAnim = default;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (stateInfo.IsTag("death"))
        {
            animator.SetBool("isDead", true);
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var controller = animator.GetComponent<BattleCharacterController>();
        if (stateInfo.IsTag("idleVariation"))
        {
            animator.SetInteger("idleVariation", 0);
        } else if (stateInfo.IsTag("takeDamage"))
        {
            animator.SetBool("isDamaged", false);
        }
        else
        {
            controller.ResetCharacter(hasResetAnim);
        }
    }


    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
