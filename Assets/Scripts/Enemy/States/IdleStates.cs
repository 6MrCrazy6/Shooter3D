using UnityEngine;

public class IdleStates : StateMachineBehaviour
{
    private float timer;
    private Transform player;
    private float chaseRange = 6; 

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 0;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer += Time.deltaTime;
        if(timer > 5)
        {
            animator.SetBool("isPatrolling", true);
        }
        else
        {
            animator.SetBool("isPatrolling", false);
        }

        float distance = Vector3.Distance(player.position, animator.transform.position);
        if(distance < chaseRange)
        {
            animator.SetBool("isChasing", true);
        }
        else
        {
            animator.SetBool("isPatrolling", true);
        }
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
