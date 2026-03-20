using System;
using UnityEngine;

public abstract class State<TStateManager, TState> : MonoBehaviour
    where TStateManager : StateManager<TStateManager, TState>
    where TState : State<TStateManager, TState>
{
    public bool isComplete {get; protected set;}

    protected float startTime;

    public TStateManager manager;

    public Animator animator;

    public AnimationClip anim;

    public float time => Time.time - startTime;

    void Awake()
    {
        manager = transform.parent.GetComponent<TStateManager>();
    }

    public virtual void Enter(TState _lastState)
    {
        
    }
    public virtual void Do()
    {
        
    }
    public virtual void FixedDo()
    {
        
    }
    public virtual void Exit(TState _nextState)
    {
        
    }    

    public void ChangeState(TState _state)
    {
        manager.state.Exit(_state);

        if (_state != null)
        {    
            manager.state = _state;
            manager.state.Enter((TState)this);
        }
        else { Debug.Log($"STATE IS NULL, I AM {this}"); }
    }
}

