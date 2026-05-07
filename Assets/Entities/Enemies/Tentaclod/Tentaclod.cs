using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Tentaclod : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] protected Animator animator;
    [SerializeField] protected EntityStateManager manager;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            manager.currentState.ChangeState(manager.action.FindState("Idle"));
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            manager.currentState.ChangeState(manager.action.FindState("Move"));
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            manager.currentState.ChangeState(manager.action.FindState("Attack"));
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            manager.currentState.ChangeState(manager.action.FindState("Death"));
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            manager.currentState.ChangeState(manager.action.FindState("Hurt"));
        }
    }
}
