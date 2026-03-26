using Unity.VisualScripting;
using UnityEngine;

public class SpiderHurt : EntityState
{
    private readonly float hurtLength = 0.625f;

    public override void Enter(EntityState _lastState)
    {
        animator.Play(anim.name);
        startTime = Time.time;
    }
    public override void Do()
    {
        if (time >= hurtLength ) 
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
