using UnityEngine;

public class DeathState : EntityState
{

    public override void Enter(EntityState _lastState)
    {
        animator.Play(anim.name);
    }
    public override void Do()
    {
        
    }
    public override void FixedDo()
    {
        
    }
    public override void Exit()
    {
        
    }
}
