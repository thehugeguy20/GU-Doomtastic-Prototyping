using System;
using Unity.VisualScripting;
using UnityEngine;

public class Pickup : MonoBehaviour, IInteractable
{
    public Transform myPrefab;

    internal ItemCore core => GetComponentInParent<ItemCore>();

    internal Item item => core.item;

    internal GameObject parent => core.gameObject;


    public void Interact(GameObject interactor)
    {
        Debug.Log("interactor: " + interactor.name);
        
        if (interactor.TryGetComponent(out Inventory inventory))
        {
            Debug.Log("inventory!");

            if (!inventory.Add(item))
            {
                Debug.Log("inventory full");
                return;
            }

            Destroy(parent);
        }
        else
        {
            Debug.Log("no inventory?");
        }
    }
}
