using UnityEngine;

public class Hold : ObjectState
{

    public override void Enter(ObjectState _lastState)
    {
        animator.CrossFadeInFixedTime(anim.name, 0.1f);
        startTime = Time.time;
    }
    public override void Do()
    {
        if (itemManager.charge != float.NaN)
        {
            itemManager.charge = Mathf.Clamp((float)itemManager.charge + time/150, 0, 1);
        }
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
