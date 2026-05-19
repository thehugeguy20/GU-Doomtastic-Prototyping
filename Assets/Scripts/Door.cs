using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    public REALLevelManagerREAL levelManager;

    public void Interact(GameObject interactor)
    {
        if (interactor.TryGetComponent(out PlayerCore playerCore))
        {
            levelManager.ChangeLevel();
        }
        else
        {
            
        }
    }

}
