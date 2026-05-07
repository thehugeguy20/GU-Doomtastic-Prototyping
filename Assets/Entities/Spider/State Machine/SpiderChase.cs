using UnityEngine;
using UnityEngine.AI;

public class SpiderChase : EntityState
{
    public override void Enter(EntityState _lastState)
    {
        if (Vector3.Distance(this.transform.position, playerPos) < 2.3)
        {
            manager.action.state.ChangeState(manager.action.FindState("SpiderAttack"));
        }
        animator.Play(anim.name);
    }
    public override void Do()
    {
        if(agent.enabled == true)
        {
            agent.SetDestination(playerPos);
        }
        if (Vector3.Distance(this.transform.position, playerPos) < 2.3)
        {
            manager.action.state.ChangeState(manager.action.FindState("SpiderAttack"));
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