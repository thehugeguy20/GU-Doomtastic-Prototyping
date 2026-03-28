using UnityEngine;
using UnityEngine.AI;

public class SpiderChase : EntityState
{
    public override void Enter(EntityState _lastState)
    {
        if (Vector3.Distance(this.transform.position, player.transform.position) < 2.3)
        {
            manager.state.ChangeState(manager.FindState("SpiderAttack"));
        }
        animator.Play(anim.name);
    }
    public override void Do()
    {
        if(agent.enabled == true)
        {
            agent.SetDestination(player.transform.position);
        }
        if (Vector3.Distance(this.transform.position, player.transform.position) < 2.3)
        {
            manager.state.ChangeState(manager.FindState("SpiderAttack"));
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