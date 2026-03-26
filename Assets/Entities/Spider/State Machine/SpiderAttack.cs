using UnityEngine;

public class SpideAttack : EntityState
{
    public override void Enter(EntityState _lastState)
    {
        animator.Play("Ball");
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
