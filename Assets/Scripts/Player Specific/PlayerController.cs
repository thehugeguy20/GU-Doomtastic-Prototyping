using Sirenix.OdinInspector;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private RayCaster rayCaster;
    [SerializeField] private Inventory inventory;
    [SerializeField] private Equipment equipment;
    [SerializeField] private ItemDataScriptableObject swordData;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hitInfo = rayCaster.Cast(RayCaster.FindType.LineForward);

            if(hitInfo.collider.gameObject.TryGetComponent<Pickup>(out Pickup pickup))
            {
                pickup.Interact(this.gameObject);

                if (equipment.rightHand.isEmpty)
                {
                    equipment.EquipRightHand(inventory.GetLast());
                }
                else if (equipment.leftHand.isEmpty)
                {
                    equipment.EquipLeftHand(inventory.GetLast());
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (equipment.rightHand.isEmpty == false)
            {
                equipment.DropRightHand();
            }
            else if (equipment.leftHand.isEmpty == false)
            {
                equipment.DropLeftHand();
            }
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            if (equipment.rightHand.isEmpty == false && equipment.leftHand.isEmpty == false)
            {
                equipment.SwapHands();
            }
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            Item item = new(swordData);
        }
    }
}
