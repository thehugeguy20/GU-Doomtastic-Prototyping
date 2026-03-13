using UnityEngine;
using UnityEngine.AI;

public class IdleState : EntityState
{
    [SerializeField] private NavMeshAgent agent;
    public override void Enter()
    {
        animator.Play("Float");
        animator.speed = 0.5f;
    }
    public override void Do()
    {
        
    }
    public override void FixedDo()
    {
        
    }
    public override void Exit()
    {
        animator.speed = 1f;
    }
}