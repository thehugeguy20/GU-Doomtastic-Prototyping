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
            manager.state.ChangeState(manager.FindState("SpiderIdle"));
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            manager.state.ChangeState(manager.FindState("SpiderChase"));
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            manager.state.ChangeState(manager.FindState("SpiderAttack"));
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            manager.state.ChangeState(manager.FindState("SpiderDeath"));
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            manager.state.ChangeState(manager.FindState("SpiderHurt"));
        }
    }
}
