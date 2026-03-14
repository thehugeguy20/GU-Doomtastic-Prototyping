using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Tentaclod : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] protected Animator animator;

    public MoveState moveState;
    public HurtState hurtState;
    public AttackState attackState;
    public DeathState deathState;
    public IdleState idleState;
    
    internal EntityState state;

    void Awake()
    {
        hurtState.Setup(animator, this);
        attackState.Setup(animator, this);
        deathState.Setup(animator, this);
        idleState.Setup(animator, this);
        moveState.Setup(animator, this);
    }

    void Start()
    {
        state = idleState;
    }

    void Update()
    {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                state.ChangeState(idleState);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                state.ChangeState(moveState);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                state.ChangeState(attackState);
            }

            else if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                state.ChangeState(deathState);
            }

            else if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                state.ChangeState(hurtState);
            }

        state.Do();
    }
}
