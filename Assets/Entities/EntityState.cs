using UnityEngine;
using UnityEngine.AI;

public abstract class EntityState : MonoBehaviour
{

    public bool isComplete {get; protected set;}

    protected float startTime;

    protected Tentaclod host;

    internal Animator animator;

    public float time => Time.time - startTime;


    public virtual void Enter()
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
