using UnityEngine;
using System;
using System.Collections.Generic;

[Serializable]
public class Action<TManager, TState, TAction> : MonoBehaviour
where TManager : StateManager<TManager, TState, TAction>
where TState : State<TManager, TState, TAction>
where TAction : Action<TManager, TState, TAction>
{
    public List<TState> states = new();

    internal TState state;
    [SerializeField] private TState defaultState;

    public void ReturnToDefault()
    {
        state = defaultState;
    }

    void Start()
    {
        ReturnToDefault();
    }

    // public void RequestState(string name)
    // {
    //     pendingState = FindState(name);
    // }

    public TState FindState(string name)
    {
        foreach (TState state in states)
        {
            if (state.name == name)
            {
                return state;
            }
        }
        return null;
    }
}
