using System.Collections.Generic;
using UnityEngine;

public class ObjectStateManager : StateManager<ObjectStateManager, ObjectState>, IHasDependencies
{
    public ItemDataScriptableObject itemData;

    [SerializeField] internal ItemManager itemManager;

    internal GameObject host {get; private set;}

    public void SetDependencies(Dependencies deps)
    {
        host = deps.targetTransform.gameObject;
    }


}