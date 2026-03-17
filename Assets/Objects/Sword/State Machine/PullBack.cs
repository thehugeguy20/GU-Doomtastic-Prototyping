using UnityEngine;

public class PullBack : ObjectState
{
    public override void Enter(ObjectState _lastState)
    {
        animator.Play(anim.name);
        startTime = Time.time;
    }
    public override void Do()
    {
        if (time >= anim.length)
        {
            manager.state.ChangeState(manager.FindState("Hold"));
        }
    }
    public override void FixedDo()
    {
        
    }
    public override void Exit(ObjectState _nextState)
    {

    }
}
