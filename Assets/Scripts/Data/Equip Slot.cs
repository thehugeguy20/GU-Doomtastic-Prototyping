using System.Diagnostics.CodeAnalysis;
using Unity.VisualScripting;
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
            item.prefab,
            slot.position,
            slot.rotation,
            slot
        );

        
        if (currentObject.TryGetComponent<ItemCore>(out ItemCore core))
        {
            core.item = item;

            Billboard billboard = core.billboard;
            if (billboard != null)
            {
                billboard.enabled = false;
            }

            Pickup pickup = core.pickup;
            if (pickup != null)
            {
                pickup.enabled = false;
                pickup.GetComponent<Collider>().enabled = false;
            }

            ItemStateManager manager = core.manager;
            if (manager != null)
            {
                manager.EnterDefaultState();
            }
        }
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

            if (currentObject.TryGetComponent<ItemCore>(out ItemCore core))
            {
                Billboard billboard = core.billboard;
                if (billboard != null)
                {
                    billboard.enabled = true;
                }

                Pickup pickup = core.pickup;
                if (pickup != null)
                {
                    pickup.enabled = true;
                    pickup.GetComponent<Collider>().enabled = true;
                }
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
