using System.Collections.Generic;
using UnityEngine;

public class EntityStateManager : StateManager<EntityStateManager, EntityState, EntityAction>
{
    internal EnemyStats stats => GetComponentInParent<EnemyCore>().stats;
    internal EnemyCore core => GetComponentInParent<EnemyCore>();

    internal LevelCore lvlCore => GameObject.Find("Level").GetComponent<LevelCore>();
}