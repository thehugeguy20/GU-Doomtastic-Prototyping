using System.Collections.Generic;
using UnityEngine;

public class EntityStateManager : StateManager<EntityStateManager, EntityState, EntityAction>
{
    internal EnemyStats stats => GetComponentInParent<EnemyCore>().stats;
    internal EnemyCore core => GetComponentInParent<EnemyCore>();
}