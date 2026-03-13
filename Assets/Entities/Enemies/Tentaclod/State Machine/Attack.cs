using UnityEngine;

public class AttackState : EntityState
{
    public override void Enter(EntityState _lastState)
    {
        animator.Play("Attack");
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
