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
    
    EntityState state;

    private bool hunting = false;

    void Awake()
    {
        EntityState newthing = state;


        state.Setup(animator, this);
        hurtState.Setup(animator, this);
        attackState.Setup(animator, this);
        deathState.Setup(animator, this);
        idleState.Setup(animator, this);
        moveState.Setup(animator, this);
    }

    // Update is called once per frame
    void Update()
    {
        if (hunting == true)
        {
            if (Input.GetKeyDown(KeyCode.H))
            {
                hunting = false;
                Debug.Log("stop hunt");
                state = idleState;
                state.Enter();
            }
        }
        else if (Input.GetKeyDown(KeyCode.H))
        {
            hunting = true;
            state = moveState;
            state.Enter();
            Debug.Log("START hunt");
        }

        state.Do();
    }
}
