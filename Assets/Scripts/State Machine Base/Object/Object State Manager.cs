using System.Collections.Generic;
using UnityEngine;

public class ItemStateManager : StateManager<ItemStateManager, ItemState>
{
    internal Item item => GetComponentInParent<ItemCore>().item;
}