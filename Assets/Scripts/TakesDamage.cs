using NUnit.Framework;
using Sirenix.OdinInspector;
using UnityEngine;

public class TakesDamage : MonoBehaviour, IInteractable
{
    [SerializeField] protected EntityStateManager manager;

    public void Interact(GameObject interactor)
    {
        manager.state.ChangeState(manager.FindState("Hurt"));
    }
}
