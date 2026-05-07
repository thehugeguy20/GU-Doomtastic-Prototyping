using System.Collections.Generic;
using UnityEngine;

public class ItemStateManager : StateManager<ItemStateManager, ItemState, ItemAction>
{
    internal Item item => GetComponentInParent<ItemCore>().item;
    internal ItemCore core => GetComponentInParent<ItemCore>();
}