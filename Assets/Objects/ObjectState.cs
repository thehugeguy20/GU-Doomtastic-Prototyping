using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public abstract class ObjectState : MonoBehaviour
{
    public bool isComplete {get; protected set;}

    protected float startTime;

    public ObjectStateManager manager;

    public Animator animator;

    public AnimationClip anim;

    public float time => Time.time - startTime;

    void Awake()
    {
        manager = transform.parent.GetComponent<ObjectStateManager>();
    }
    public virtual void Enter(ObjectState _lastState)
    {
        
    }
    public virtual void Do()
    {
        
    }
    public virtual void FixedDo()
    {
        
    }
    public virtual void Exit(ObjectState _nextState)
    {
        
    }

    public void ChangeState(ObjectState _state)
    {
        manager.state.Exit(_state);

        if (_state != null)
        {    
            manager.state = _state;
            manager.state.Enter(this);
        }
        else { Debug.Log($"STATE IS NULL, I AM {this}"); }
    }
}
