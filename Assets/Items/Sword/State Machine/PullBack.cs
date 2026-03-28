using UnityEngine;

public class PullBack : ItemState
{
    //private float charge = 0.22f;

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
    
        if (time >= anim.length)
        {
            if (manager.pendingState != null)
            {
                ItemState nextState = manager.pendingState;
                manager.pendingState = null;
                manager.state.ChangeState(nextState);
            }
            else 
            {
                manager.state.ChangeState(manager.FindState("Hold"));
            }
        }
    }
    public override void FixedDo()
    {
        
    }
    public override void Exit(ItemState _nextState)
    {

    }
}
