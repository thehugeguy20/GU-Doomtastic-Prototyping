using NUnit.Framework;
using Sirenix.OdinInspector;
using UnityEngine;

public class Swing : ObjectState
{
    private bool hit = false;
    [SerializeField] private RayCaster rayCaster;
    public GameObject waterspawn;

    public override void Enter(ObjectState _lastState)
    {
        animator.Play(anim.name);
        startTime = Time.time;
    }
    public override void Do()
    {

        if(hit == false && time >= anim.length-anim.length/3)
        {
            RaycastHit hitInfo = rayCaster.Cast();

            if(hitInfo.collider != null)
            {
                foreach (IInteractable iinteractable in hitInfo.collider.gameObject.GetComponents<IInteractable>())
                {
                    iinteractable.Interact(this.gameObject);
                }

                // if(hitInfo.collider.TryGetComponent(out IKnockbackable knockbackable))
                // {
                    
                // }
            }

            hit = true;
        }

        if (time >= anim.length)
        {
            manager.state.ChangeState(manager.FindState("Idle"));
        }
    }

    public override void FixedDo()
    {
        
    }
    public override void Exit(ObjectState _nextState)
    {
        hit = false;
    }
}
