using UnityEngine;

public class Hold : ItemState
{

    public override void Enter(ItemState _lastState)
    {
        animator.CrossFadeInFixedTime(anim.name, 0.1f);
        startTime = Time.time;
    }
    public override void Do()
    {
        if (item.charge != float.NaN)
        {
            item.charge = Mathf.Clamp((float)item.charge + time/150, 0, 1);
        }
    }
    public override void FixedDo()
    {
        
    }
    public override void Exit(ItemState _nextState)
    {
        if (_nextState.name == "Swing")
        {
            //_nextState.anim
        }
    }
}
