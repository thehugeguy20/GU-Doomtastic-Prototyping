using UnityEngine;

public class SpiderAttack : EntityState
{
    public override void Enter(EntityState _lastState)
    {
        animator.Play("Ball");
        startTime = Time.time;
    }
    public override void Do()
    {
        if (time > 0.8f && !(Vector3.Distance(this.transform.position, player.transform.position) < 2.3))
        {
            manager.state.ChangeState(manager.FindState("SpiderChase"));
        }
    }
    public override void FixedDo()
    {
        
    }
    public override void Exit(EntityState _nextState)
    {

    }
}
