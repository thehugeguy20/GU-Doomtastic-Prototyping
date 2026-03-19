using System.Collections.Generic;
using UnityEngine;

public class ObjectStateManager : MonoBehaviour
{
    internal ObjectState state;

    [SerializeField] private ObjectState defaultState;

    public List<ObjectState> states = new();
    
    void Start()
    {
        state = defaultState;
    }

    void Update()
    {
        state.Do();
    }

    public ObjectState FindState(string name)
    {
        foreach (ObjectState state in states)
        {
            if (state.name == name)
{
                return state;
            }
        }
        return null;
    }

}