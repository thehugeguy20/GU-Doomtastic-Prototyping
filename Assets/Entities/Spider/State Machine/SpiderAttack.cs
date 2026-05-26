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
            Debug.Log("spider_attacking");
            //player.GetComponentInParent<PlayerCore>().stats.health -= 1f;
            GameObject.Find("Player").GetComponent<PlayerStats>().health -=1f;

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
