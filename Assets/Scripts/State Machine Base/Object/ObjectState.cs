using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public abstract class ObjectState : State<ObjectStateManager, ObjectState>
{
    internal ItemManager itemManager => manager.itemManager;
}
