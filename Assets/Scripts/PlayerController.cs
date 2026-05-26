using Sirenix.OdinInspector;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private RayCaster rayCaster;
    [SerializeField] private Inventory inventory;
    [SerializeField] private Equipment equipment;
    [SerializeField] private ItemDataScriptableObject swordData;
    [SerializeField] private PlayerCore playerCore;
    [SerializeField] private EquipSlot rightHand;
    [SerializeField] private EquipSlot leftHand;

    [SerializeField] private bool goingToAttack;

    public GameObject inventoryUI;
    private bool inInventory = false;

    void Start()
    {
        if (inventoryUI == null)
        {
            inventoryUI = GameObject.Find("Inventory");
        }
    }

    void Update()
    {

        if(Input.GetKeyDown(KeyCode.E))
        {
            //cast a ray from camera, and returns information about what was hit (if something was)
            RaycastHit hitInfo = rayCaster.Cast(RayCaster.FindType.LineForward);

            // if the collider's gameobject has a pickup.cs component,
            if(hitInfo.collider.gameObject.TryGetComponent<Pickup>(out Pickup pickup))
            {
                // then call that pickup's interact function, telling it that we've called it by passing it ourselves (this.gameobject)
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

            // if the collider is a door
            if(hitInfo.collider.gameObject.TryGetComponent<Door>(out Door door))
            {
                // then call that door's interact function, telling it that we've called it by passing it ourselves (this.gameobject)
                door.Interact(this.gameObject);
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

        if (Input.GetKeyDown(KeyCode.I))
        {
            if (inInventory == true)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                inInventory = false;
                inventoryUI.SetActive(false);
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                inInventory = true;
                inventoryUI.SetActive(true);
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (!rightHand.isEmpty)
            {
                rightHand.GetComponentInChildren<ItemCore>().manager.action.state.ChangeState(rightHand.GetComponentInChildren<ItemCore>().manager.action.FindState("PullBack"));
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (!rightHand.isEmpty)
            {
                if (rightHand.GetComponentInChildren<ItemCore>().manager.action.state.name == "Hold")
                {
                    rightHand.GetComponentInChildren<ItemCore>().manager.action.state.ChangeState(rightHand.GetComponentInChildren<ItemCore>().manager.action.FindState("Swing"));
                }
                else if (rightHand.GetComponentInChildren<ItemCore>().manager.action.state.name == "PullBack")
                {
                    goingToAttack = true;
                }
            }
        }

        if (!rightHand.isEmpty && rightHand.GetComponentInChildren<ItemCore>().manager.action.state.name == "PullBack" && goingToAttack == true)
        {
            rightHand.GetComponentInChildren<ItemCore>().manager.action.state.ChangeState(rightHand.GetComponentInChildren<ItemCore>().manager.action.FindState("Swing"));
            goingToAttack = false;
        }

    }

}
