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
                state.Exit();
                EntityState lastState = state;
                state = idleState;
                state.Enter(lastState);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                state.Exit();
                EntityState lastState = state;
                state = moveState;
                state.Enter(lastState);
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                state.Exit();
                EntityState lastState = state;
                state = attackState;
                state.Enter(lastState);
            }

            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                state.Exit();
                EntityState lastState = state;
                state = deathState;
                state.Enter(lastState);
            }

            if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                state.Exit();
                EntityState lastState = state;
                state = hurtState;
                state.Enter(lastState);
            }
        

        state.Do();
    }
}
