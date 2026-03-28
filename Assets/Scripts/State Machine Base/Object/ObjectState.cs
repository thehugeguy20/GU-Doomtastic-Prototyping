using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public abstract class ItemState : State<ItemStateManager, ItemState>
{
    internal Item item => manager.item;
}
