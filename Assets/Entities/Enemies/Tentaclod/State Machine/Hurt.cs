using UnityEngine;

public class HurtState : EntityState
{
    private readonly float hurtLength = 0.625f;

    public override void Enter(EntityState _lastState)
    {
        animator.Play(anim.name);
        startTime = Time.time;
    }
    public override void Do()
    {
        if (time >= hurtLength)
        {
            ChangeState(host.moveState);
        }
    }
    public override void FixedDo()
    {
        
    }
    public override void Exit()
    {
        
    }
    
}
