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

        
        if (currentObject.TryGetComponent<ItemContext>(out ItemContext itemContext))
        {
            itemContext.item = item;

            Billboard billboard = itemContext.billboard;
            if (billboard != null)
            {
                billboard.enabled = false;
            }

            Pickup pickup = itemContext.pickup;
            if (pickup != null)
            {
                pickup.enabled = false;
                pickup.GetComponent<Collider>().enabled = false;
            }

            ItemStateManager manager = itemContext.manager;
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

            if (currentObject.TryGetComponent<ItemContext>(out ItemContext itemContext))
            {
                Billboard billboard = itemContext.billboard;
                if (billboard != null)
                {
                    billboard.enabled = true;
                }

                Pickup pickup = itemContext.pickup;
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
