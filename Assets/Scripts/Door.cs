using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{

    public REALLevelManagerREAL levelManager;

    void Start()
    {
        levelManager = GameObject.Find("Level Manager").GetComponent<REALLevelManagerREAL>();
    }

    public void Interact(GameObject interactor)
    {
        if (interactor.TryGetComponent(out PlayerCore playerCore))
        {
            Debug.Log("door time");
            if (levelManager.aliveEnemies == 0)
            {
                levelManager.ChangeLevel();
            }
        }
    }
}
