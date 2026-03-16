using System.Collections.Generic;
using UnityEngine;

public class EntityStateManager : MonoBehaviour
{
    internal EntityState state;

    [SerializeField] private EntityState defaultState;

    public List<EntityState> states = new();
    
    void Start()
    {
        state = defaultState;
    }

    void Update()
    {
        state.Do();
    }

    public EntityState FindState(string name)
    {
        foreach (EntityState state in states)
        {
            if (state.name == name)
{
                return state;
            }
        }
        return null;
    }

}
