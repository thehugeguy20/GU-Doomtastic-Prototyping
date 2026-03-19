using NUnit.Framework;
using Sirenix.OdinInspector;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private RayCaster rayCaster;
    [SerializeField] private GameObject rightHand;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hitInfo = rayCaster.Cast();

            if(hitInfo.collider.gameObject.TryGetComponent<Pickup>(out Pickup pickup))
            {
                pickup.Interact(rightHand);
            }
        }
    }
}
