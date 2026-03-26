using UnityEngine;
using UnityEngine.AI;

public class SpiderIdle : EntityState
{
    [SerializeField] private NavMeshAgent agent;
    

    public override void Enter(EntityState _lastState)
    {
        animator.Play("Idle");
        animator.speed = 0.5f;
    }
    public override void Do()
    {
        
    }
    public override void FixedDo()
    {
        
    }
    public override void Exit(EntityState _nextState)
    {
        animator.speed = 1f;
    }
}