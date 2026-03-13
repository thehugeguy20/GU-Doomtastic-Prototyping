using UnityEngine;
using UnityEngine.AI;

public class MoveState : EntityState
{
    [SerializeField] private NavMeshAgent agent;
    public override void Enter()
    {
        animator.Play("Float");
    }
    public override void Do()
    {
        GameObject playerObj = GameObject.Find("Player");
        agent.SetDestination(playerObj.transform.position);
    }
    public override void FixedDo()
    {
        
    }
    public override void Exit()
    {
        agent.SetDestination(this.transform.position);
    }
}