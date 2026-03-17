using System.Collections;
using NUnit.Framework.Constraints;
using UnityEngine;
using UnityEngine.AI;

public abstract class EntityState : MonoBehaviour
{
    public bool isComplete {get; protected set;}

    
    protected float startTime;

    protected EntityStateManager manager;

    public Animator animator;

    public AnimationClip anim;

    public float time => Time.time - startTime;

    void Awake()
    {
        manager = transform.parent.GetComponent<EntityStateManager>();
    }


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

    public void ChangeState(EntityState _state)
    {
        manager.state.Exit();

        if (_state != null)
        {    
            manager.state = _state;
            manager.state.Enter(this);
        }
        else { Debug.Log($"STATE IS NULL, I AM {this}"); }
    }
}
