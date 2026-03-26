using System.Collections.Generic;
using UnityEngine;

public class EntityStateManager : StateManager<EntityStateManager, EntityState>
{
    internal EnemyStats stats => GetComponentInParent<EnemyCore>().stats;
}