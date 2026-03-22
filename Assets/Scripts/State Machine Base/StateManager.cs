using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class StateManager<TManager, TState> : MonoBehaviour
where TManager : StateManager<TManager, TState>
where TState : State<TManager, TState>
{
    internal TState state;
    public TState pendingState;
    [SerializeField] private TState defaultState;
    public List<TState> states = new();

    void Start()
    {
        state = defaultState;
    }

    void Update()
    {
        state.Do();
    }

    public void RequestState(string name)
    {
        pendingState = FindState(name);
    }

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
