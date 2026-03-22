using UnityEngine;

public class PullBack : ObjectState
{
    //private float charge = 0.22f;

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
    
        if (time >= anim.length)
        {
            if (manager.pendingState != null)
            {
                ObjectState nextState = manager.pendingState;
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
    public override void Exit(ObjectState _nextState)
    {

    }
}
