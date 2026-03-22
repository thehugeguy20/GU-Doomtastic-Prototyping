using CameraShake;
using NUnit.Framework;
using Sirenix.OdinInspector;
using UnityEngine;

public class Swing : ObjectState
{
    private bool hit = false;
    [SerializeField] private RayCaster rayCaster;
    public GameObject waterspawn;
    [SerializeField] private float hitStopLength;


    public override void Enter(ObjectState _lastState)
    {
        animator.CrossFadeInFixedTime(anim.name, 0.1f);
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

                if(hitInfo.collider.gameObject.TryGetComponent(out IKnockbackable knockbackable) && itemManager.charge != float.NaN)
                {
                    Debug.Log("has knockbackable, Charge found in properties");

                    Vector3 force = manager.itemData.GetKnockbackStrength(hitInfo.collider.gameObject.transform.parent.GetComponentInChildren<Billboard>().gameObject.transform.forward, itemManager.charge);

                    knockbackable.GetKnockedBack(force);
                }

                TimeScaleManager.singleton.HitStop(hitStopLength); 

                CameraShaker.Presets.Explosion3D(strength:8,duration:0.2f);
                
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
        if (itemManager.charge != float.NaN)
        {
            itemManager.charge = 0f; 
        }
    }
}
