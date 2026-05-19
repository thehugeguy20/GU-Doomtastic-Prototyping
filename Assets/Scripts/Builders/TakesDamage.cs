using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class TakesDamage : MonoBehaviour, ITakeDamage, IKnockbackable
{
    [SerializeField] protected EntityStateManager manager;
    [SerializeField] internal Rigidbody rig; 
    [SerializeField] private NavMeshAgent agent;
    [Range(0.001f, 0.1f)][SerializeField] private float stillTresh = 0.05f;

    public void TakeDamage(Item item)
    {
        if (manager.stats.health.value - item.damage.total <= 0)
        {
            manager.currentState.ChangeState(manager.action.FindState("SpiderDeath"));
        }
        else
        {
            manager.stats.health.changes -= item.damage.total;
            manager.currentState.ChangeState(manager.action.FindState("SpiderHurt"));
        }
    }

    public void GetKnockedBack(Vector3 force)
    {
        Debug.Log("Knocking back with " + force + "force") ;
        StartCoroutine(ApplyKnockback(force));
    }

    private IEnumerator ApplyKnockback(Vector3 force)
    {
        // turn off the navmesh agent, disable kinematic (now it's physics is handled by unity) & enable gravity. then add the given force
        yield return null;
        agent.enabled = false;
        rig.useGravity = true;
        rig.isKinematic = false;
        rig.AddForce(force);

        // wait until the next fixed update so that this physics process happens in line with all of unity's, and then wait until the magnitude/amount of this object's linear velocity is lower than the threshhold we set that will determine when to set this object still again
        yield return new WaitUntil(() => rig.linearVelocity.magnitude < stillTresh);
        // then wait a little longer to let unity do its thang
        yield return new WaitForSeconds(0.25f);

        // set all velocity to 0 (stop it from moving) and turn gravity off and change isKinematic back to true so that we can do whatever we want with the object
        rig.linearVelocity = Vector3.zero;
        rig.angularVelocity = Vector3.zero;
        rig.useGravity = false;
        rig.isKinematic = true;

        // make sure to warp the navmesh agent to wherever we've landed because it doesn't move with our rigidbody
        agent.Warp(transform.position);
        //then turn it back on!
        agent.enabled = true;

        yield break;
    }
}
