using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class TakesDamage : MonoBehaviour, IInteractable, IKnockbackable
{
    [SerializeField] protected EntityStateManager manager;
    [SerializeField] internal Rigidbody rig; 
    [SerializeField] private NavMeshAgent agent;
    [Range(0.001f, 0.1f)][SerializeField] private float stillTresh = 0.05f;

    public void Interact(GameObject interactor)
    {
        manager.state.ChangeState(manager.FindState("Hurt"));
    }

    public void GetKnockedBack(Vector3 force)
    {
        Debug.Log("Knocking back with " + force + "force") ;
        StartCoroutine(ApplyKnockback(force));
    }

    private IEnumerator ApplyKnockback(Vector3 force)
    {
        yield return null;
        agent.enabled = false;
        rig.useGravity = true;
        rig.isKinematic = false;
        rig.AddForce(force);

        yield return new WaitForFixedUpdate();
        yield return new WaitUntil(() => rig.linearVelocity.magnitude < stillTresh);
        yield return new WaitForSeconds(0.25f);

        rig.linearVelocity = Vector3.zero;
        rig.angularVelocity = Vector3.zero;
        rig.useGravity = false;
        rig.isKinematic = true;

        agent.Warp(transform.position);
        agent.enabled = true;

        yield break;
    }
}
