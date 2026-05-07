using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Spider : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] protected Animator animator;
    [SerializeField] protected EntityStateManager manager;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            manager.currentState.ChangeState(manager.action.FindState("SpiderIdle"));
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            manager.currentState.ChangeState(manager.action.FindState("SpiderChase"));
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            manager.currentState.ChangeState(manager.action.FindState("SpiderAttack"));
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            manager.currentState.ChangeState(manager.action.FindState("SpiderDeath"));
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            manager.action.state.ChangeState(manager.action.FindState("SpiderHurt"));
        }
    }
}
