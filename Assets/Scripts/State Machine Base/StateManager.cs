using System.Collections.Generic;
using UnityEngine;

public class StateManager<TManager, TState> : MonoBehaviour
where TManager : StateManager<TManager, TState>
where TState : State<TManager, TState>

{

    internal TState state;
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
