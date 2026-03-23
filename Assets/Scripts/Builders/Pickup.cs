using System;
using UnityEngine;

public class Pickup : MonoBehaviour, IInteractable
{
    public Transform myPrefab;

    [SerializeField] private GameObject parent;
    [SerializeField] private Billboard billboard;
    [SerializeField] private CapsuleCollider col;
    public GameObject holder;

    internal ItemInit itemInit => GetComponentInParent<ItemInit>();
    internal Item item => itemInit.item;

    public void Interact(GameObject interactor)
    {
        Debug.Log("interactor: " + interactor.name);
        
        if (interactor.TryGetComponent(out Inventory inventory))
        {

            if (!inventory.Add(item))
            {
                Debug.Log("inventory full");
                return;
            }

            Destroy(itemInit.gameObject);
        }
    }
}
