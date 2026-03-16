using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Tentaclod : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] protected Animator animator;
    [SerializeField] protected EntityStateManager manager;

    internal EntityState state;

    void Update()
    {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                manager.state.ChangeState(manager.FindState("Idle"));
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                manager.state.ChangeState(manager.FindState("Move"));
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                state.ChangeState(manager.FindState("Attack"));
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                state.ChangeState(manager.FindState("Death"));
            }
            else if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                manager.state.ChangeState(manager.FindState("Hurt"));
            }

        Debug.Log($"state = {manager.state}");
    }
}
