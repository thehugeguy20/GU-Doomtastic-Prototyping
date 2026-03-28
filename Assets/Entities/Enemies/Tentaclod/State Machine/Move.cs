using UnityEngine;
using UnityEngine.AI;

public class MoveState : EntityState
{
    [SerializeField] private NavMeshAgent agent;
    
    GameObject player;

    public override void Enter(EntityState _lastState)
    {
        player = GameObject.Find("Player");
        animator.Play(anim.name);
    }
    public override void Do()
    {
        if(agent.enabled == true)
        {
            agent.SetDestination(player.transform.position);
        }
    }
    public override void FixedDo()
    {
        
    }
    public override void Exit(EntityState _nextState)
    {
        agent.SetDestination(this.transform.position);
    }
}