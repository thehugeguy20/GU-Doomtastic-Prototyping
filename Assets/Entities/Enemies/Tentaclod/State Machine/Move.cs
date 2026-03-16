using UnityEngine;
using UnityEngine.AI;

public class MoveState : EntityState
{
    [SerializeField] private NavMeshAgent agent;
    
    GameObject player;

    public override void Enter(EntityState _lastState)
    {
        Debug.Log("IM ENTER MOVE!!!!");
        player = GameObject.Find("Player");
        animator.Play(anim.name);
    }
    public override void Do()
    {
        Debug.Log("IM TRYING T MOVE PLEASE");
        agent.SetDestination(player.transform.position);
    }
    public override void FixedDo()
    {
        
    }
    public override void Exit()
    {
        agent.SetDestination(this.transform.position);
    }
}