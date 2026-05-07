using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public abstract class EntityState : State<EntityStateManager, EntityState, EntityAction>
{
    protected NavMeshAgent agent => manager.core.GetComponentInChildren<NavMeshAgent>();
    protected GameObject player =>  GameObject.Find("Player");
    protected Vector3 playerPos => player.GetComponentInChildren<PlayerCharacter>().transform.position;
}
