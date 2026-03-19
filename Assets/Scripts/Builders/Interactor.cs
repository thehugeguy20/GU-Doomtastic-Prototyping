using UnityEngine;



public class Interactor : MonoBehaviour
{
    public Transform InteractorSource;
    public float InteractRange;

    public void CallInteraction(GameObject obj)
    {
        if (obj.TryGetComponent(out IInteractable interactable))
        {
            interactable.Interact(this.gameObject);
        }
    }
}
