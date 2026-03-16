using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public abstract class EntityState : MonoBehaviour
{
    public bool isComplete {get; protected set;}

    protected float startTime;

    public EntityStateManager manager;

    public Animator animator;

    public AnimationClip anim;

    protected EntityState lastState;

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
