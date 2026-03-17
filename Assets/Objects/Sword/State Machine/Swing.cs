using UnityEngine;

public class Swing : ObjectState
{
    public override void Enter(ObjectState _lastState)
    {
        animator.Play(anim.name);
        startTime = Time.time;
    }
    public override void Do()
    {

    }
    public override void FixedDo()
    {
        
    }
    public override void Exit(ObjectState _nextState)
    {

    }
}
