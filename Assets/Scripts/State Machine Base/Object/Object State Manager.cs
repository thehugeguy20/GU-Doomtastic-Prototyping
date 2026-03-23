using System.Collections.Generic;
using UnityEngine;

public class ItemStateManager : StateManager<ItemStateManager, ItemState>
{
    [SerializeField] internal Item item;
}