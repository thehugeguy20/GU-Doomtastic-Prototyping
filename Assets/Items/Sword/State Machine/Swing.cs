using CameraShake;
using Sirenix.OdinInspector;
using UnityEngine;

public class Swing : ItemState
{
    private bool hit = false;
    [SerializeField] private float hitStopLength;

    RayCaster rayCaster => transform.root.GetComponentInChildren<RayCaster>();

    public override void Enter(ItemState _lastState)
    {
        animator.CrossFadeInFixedTime(anim.name, 0.1f);
        startTime = Time.time;
    }
    public override void Do()
    {

        if(hit == false && time >= anim.length-anim.length/3 && rayCaster != null)
        {
            RaycastHit hitInfo = rayCaster.Cast(RayCaster.FindType.LineForward);

            if(hitInfo.collider != null)
            {
                foreach (ITakeDamage damagee in hitInfo.collider.gameObject.GetComponents<ITakeDamage>())
                {
                    damagee.TakeDamage(manager.item);
                }

                if(hitInfo.collider.gameObject.TryGetComponent(out IKnockbackable knockbackable) && item.charge != float.NaN)
                {
                    Debug.Log("has knockbackable, Charge found in properties");

                    Vector3 billboardForward = hitInfo.collider.transform.parent.GetComponentInChildren<Billboard>().transform.forward;

                    Item debugItem = manager.item;

                    GameObject debugBase = item.Base.prefab;

                    float debugCharge = item.charge;

                    float debugsum = 3 + item.charge;

                    Vector3 force = manager.item.GetKnockbackStrength(billboardForward, item.charge);

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
    public override void Exit(ItemState _nextState)
    {
        hit = false;
        if (item.charge != float.NaN)
        {
            item.charge = 0f; 
        }
    }
}
