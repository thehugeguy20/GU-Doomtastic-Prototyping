using System.Diagnostics.CodeAnalysis;
using UnityEditor;
using UnityEngine;

public class EquipSlot : MonoBehaviour
{
    [SerializeField] private Transform slot;

    private GameObject currentObject;
    internal Item currentItem;

    public bool isEmpty => currentItem == null;

    public void Equip(Item item)
    {
        if (!isEmpty) 
        {
            Unequip(dropItem:true);
        }

        currentItem = item;

        currentObject = Instantiate(
            item.base_.prefab,
            slot.position,
            slot.rotation,
            slot
        );

        currentObject.GetComponentInChildren<Billboard>().enabled = false;

        Debug.Log("After instantiate: " + currentObject.transform.localRotation.eulerAngles);

        Debug.Log("After parent set: " + currentObject.transform.localRotation.eulerAngles);
        
        Animator animator = currentObject.GetComponentInChildren<Animator>();
    
        // if(this.name == "Right Hand")
        // {
        //     currentObject.transform.SetLocalPositionAndRotation(Vector3.zero, item.base_.prefab.transform.localRotation);
        // }
        // else if (this.name == "Left Hand")
        // {
        //     currentObject.transform.SetLocalPositionAndRotation(Vector3.zero, item.base_.prefab.transform.localRotation);
        // }

        Pickup pickup = currentObject.GetComponentInChildren<Pickup>();
        if (pickup != null)
        {
            pickup.enabled = false;
            pickup.GetComponent<Collider>().enabled = false;
        }

        ItemStateManager manager = currentObject.GetComponentInChildren<ItemStateManager>();
        if (manager != null)
        {
            manager.item = item;
            manager.EnterDefaultState();
        }

        Debug.Log("After EnterDefaultState: " + currentObject.transform.localRotation.eulerAngles);

        currentObject.transform.SetLocalPositionAndRotation(Vector3.zero, item.base_.prefab.transform.localRotation);

        Debug.Log("what are you:" + item.base_.prefab.transform.localRotation.eulerAngles);

        Debug.Log("Final rotation: " + currentObject.transform.localRotation.eulerAngles);
    }

    public Item Unequip(bool dropItem)
    {
        if (isEmpty) 
        {
            return null;
        }

        if(dropItem == true)
        {
            currentObject.transform.SetParent(null);
            currentObject.GetComponentInChildren<Billboard>().enabled = true;

            Pickup pickup = currentObject.GetComponentInChildren<Pickup>();

            if (pickup != null)
            {
                pickup.enabled = true;
                pickup.GetComponent<Collider>().enabled = true;
            }
        }
        else
        {
            Destroy(currentObject);
        }

        Item droppedItem = currentItem;
        currentItem = null;
        currentObject = null;
        return droppedItem;
    }

    public void IsEnabled(bool isEnabled)
    {
        if (currentObject != null)
        {
            currentObject.SetActive(isEnabled);
        }
    }
}
