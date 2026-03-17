using UnityEngine;

public class Hold : ObjectState
{

    public override void Enter(ObjectState _lastState)
    {
        animator.Play(anim.name);
        startTime = Time.time;
    }
    public override void Do()
    {
        // if (time >= anim.length)
        // {
        //     manager.state.ChangeState(manager.FindState("Swing"));
        // }
    }
    public override void FixedDo()
    {
        
    }
    public override void Exit(ObjectState _nextState)
    {
        if (_nextState.name == "Swing")
        {
            //_nextState.anim
        }
    }
}
