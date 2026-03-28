using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public abstract class EntityState : State<EntityStateManager, EntityState>
{
    protected NavMeshAgent agent => manager.core.GetComponentInChildren<NavMeshAgent>();
    protected GameObject player => GameObject.Find("Player");
}
