using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot_Movement : StateMachineBehaviour
{
    [SerializeField] private float AttackDistance = 1.5f;

    private Transform player;
    private Rigidbody2D rb;
    [SerializeField] private float speed;
    [SerializeField] private float AttackSpeed;
    private float nextTimeToAttack;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponentInParent<Rigidbody2D>();
        speed = animator.GetComponentInParent<BotStats>().Speed;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector2 target = new Vector2(player.position.x, rb.position.y);
        Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
        
        float distance = Vector2.Distance(player.position, rb.position);
        Debug.Log(distance);
        if (distance <= AttackDistance)
        {
            if(nextTimeToAttack <= 0)
            {
                if (Random.value <= 0.5f)
                {
                    animator.SetTrigger("punch");
                }
                else
                {
                    animator.SetTrigger("kick");
                }

                nextTimeToAttack = AttackSpeed;
            }
            else
            {
                nextTimeToAttack -= Time.fixedDeltaTime;
            }
            
        }
        else
        {
            rb.MovePosition(newPos);
        }

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("punch");
        animator.ResetTrigger("kick");
        nextTimeToAttack = AttackSpeed;
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
