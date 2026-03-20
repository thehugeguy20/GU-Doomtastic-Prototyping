using Unity.VisualScripting;
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
        Debug.Log(time);
        if (time >= hurtLength ) 
        {
            Debug.Log("TRYING TO CHANGE STATE TO HURT");
            manager.state.ChangeState(manager.FindState("Move"));
        }

    }
    public override void FixedDo()
    {
        
    }
    public override void Exit(EntityState _nextState)
    {
        
    }
    
}
