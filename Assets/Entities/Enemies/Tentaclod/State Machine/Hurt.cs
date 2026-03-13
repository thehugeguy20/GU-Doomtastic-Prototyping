using UnityEngine;

public class HurtState : EntityState
{
    private readonly float hurtLength = 0.625f;

    public override void Enter(EntityState _lastState)
    {
        animator.Play("Hurt");
        startTime = Time.time;
    }
    public override void Do()
    {
        if (time >= hurtLength)
        {
            Exit();
        }
    }
    public override void FixedDo()
    {
        
    }
    public override void Exit()
    {
        host.state = host.moveState;
        host.state.Enter(this);
    }

}
