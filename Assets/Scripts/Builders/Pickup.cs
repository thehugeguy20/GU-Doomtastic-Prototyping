using System;
using UnityEngine;

public class Pickup : MonoBehaviour, IInteractable
{
    public Transform myPrefab;

    [SerializeField] private GameObject parent;
    [SerializeField] private Billboard billboard;
    [SerializeField] private CapsuleCollider col;
    public GameObject holder;

    public void Interact(GameObject interactor)
    {
        
        parent.GetComponentInChildren<RayCaster>().rayOrigin = holder.GetComponentInChildren<Camera>().transform;

        billboard.enabled = false;
        col.enabled = false;
        parent.transform.SetParent(interactor.transform);
        parent.transform.localPosition = myPrefab.localPosition;
        parent.transform.localRotation = myPrefab.localRotation;
        parent.transform.localScale = myPrefab.localScale;

    }
}
