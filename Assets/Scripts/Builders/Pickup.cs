using System;
using UnityEngine;

public class Pickup : MonoBehaviour, IInteractable
{
    public Transform setme;

    [SerializeField] private GameObject parent;
    [SerializeField] private Billboard billboard;
    [SerializeField] private CapsuleCollider col;
    public void Interact(GameObject interactor)
    {
        billboard.enabled = false;
        col.enabled = false;
        parent.transform.SetParent(interactor.transform);
        parent.transform.localPosition = setme.localPosition;
        parent.transform.localRotation = setme.localRotation;
        parent.transform.localScale = setme.localScale;

    }
}
