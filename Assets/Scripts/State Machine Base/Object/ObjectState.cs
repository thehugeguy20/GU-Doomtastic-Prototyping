using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public abstract class ItemState : State<ItemStateManager, ItemState, ItemAction>
{
    internal Item item => manager.item;
}
