using UnityEngine;

public class SpiderDeath : EntityState
{

    public override void Enter(EntityState _lastState)
    {
        animator.Play("Death");
    }
    public override void Do()
    {
        
    }
    public override void FixedDo()
    {
        
    }
    public override void Exit(EntityState _nextState)
    {
        
    }
}
