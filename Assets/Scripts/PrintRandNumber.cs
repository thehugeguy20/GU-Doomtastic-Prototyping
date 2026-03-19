using UnityEngine;

public class PrintRandNumber : MonoBehaviour, IInteractable
{
    public void Interact(GameObject interactor)
    {
        Debug.Log(Random.Range(0,100));
    }

}