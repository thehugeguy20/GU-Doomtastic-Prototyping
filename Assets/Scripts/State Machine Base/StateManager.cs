using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class StateManager<TManager, TState, TAction> : MonoBehaviour
where TManager : StateManager<TManager, TState, TAction>
where TState : State<TManager, TState, TAction>
where TAction : Action<TManager, TState, TAction>
{
    internal TAction action;
    public TState pendingState;
    [SerializeField] private TAction defaultAction;
    public TState currentState => action.state;

    void Start()
    {
        action = defaultAction;
    }

    void Update()
    {
        if (action != null)
        {
            action.state.Do();
        }
    }

    public void EnterDefaultAction()
    {
        action = defaultAction;

        action.ReturnToDefault();

        action.state.Enter(null);
    }

}