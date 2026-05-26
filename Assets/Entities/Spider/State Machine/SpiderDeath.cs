using UnityEngine;

public class SpiderDeath : EntityState
{

    public override void Enter(EntityState _lastState)
    {
        animator.Play("Death");

        REALLevelManagerREAL lvlManager = GameObject.Find("Level Manager").GetComponent<REALLevelManagerREAL>();

        lvlManager.aliveEnemies = lvlManager.aliveEnemies - 1;

    }
    public override void Do()
    {
        
    }
    public override void FixedDo()
    {
        
    }
    public override void Exit(EntityState _nextState)
    {
        
    }
}
