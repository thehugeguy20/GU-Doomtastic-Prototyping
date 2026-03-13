using UnityEngine;
using UnityEngine.AI;

public abstract class EntityState : MonoBehaviour
{
    public bool isComplete {get; protected set;}

    protected float startTime;

    protected Tentaclod host;

    protected Animator animator;

    protected EntityState lastState;

    public float time => Time.time - startTime;


    public virtual void Enter(EntityState _lastState)
    {
        
    }
    public virtual void Do()
    {
        
    }
    public virtual void FixedDo()
    {
        
    }
    public virtual void Exit()
    {
        
    }

    public void Setup(Animator _animator, Tentaclod _host)
    {
        animator = _animator;
        host = _host;
    }
}
