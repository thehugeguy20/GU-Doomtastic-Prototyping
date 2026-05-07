using UnityEngine;

public class SpiderAttack : EntityState
{
    private bool attacked;

    public override void Enter(EntityState _lastState)
    {
        attacked = false;

        animator.Play("Ball");
        startTime = Time.time;
    }
    public override void Do()
    {
        if (attacked == false && time > 0.5f && Vector3.Distance(this.transform.position, playerPos) < 2.3)
        {
            player.GetComponentInParent<PlayerCore>().stats.health.ChangeStat(manager.stats.damage.value);

            attacked = true;
        }
        if (time > 0.8f && Vector3.Distance(this.transform.position, playerPos) > 2.3)
        {
            manager.currentState.ChangeState(manager.action.FindState("SpiderChase"));
        }
    }
    public override void FixedDo()
    {
        
    }
    public override void Exit(EntityState _nextState)
    {

    }
}
