using NUnit.Framework;
using Sirenix.OdinInspector;
using UnityEngine;

public struct Dependencies
{
    public Transform transform;
    public Camera camera;
}

public interface IHasDependencies
{
    void SetDependencies(Dependencies deps);
}

public interface IInteractable
{
    void Interact(GameObject interactor);
}
