using System.Collections.Generic;
using UnityEngine;

public class ItemStateManager : StateManager<ItemStateManager, ItemState>, IHasDependencies
{
    [SerializeField] internal Item item;

    internal GameObject host {get; private set;}

    public void SetDependencies(Dependencies deps)
    {
        host = deps.targetTransform.gameObject;
    }


}