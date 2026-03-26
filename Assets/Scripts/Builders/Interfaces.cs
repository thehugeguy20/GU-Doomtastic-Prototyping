using Sirenix.OdinInspector;
using UnityEngine;

public struct Dependencies
{
    //transform of each component
    public Transform myTransform;

    // aka the top parent of the "object" . sword's top transform will always be it's own transform, and never whoever's holding the sword's transform
    public Transform objectTransform;

    // aka a sword which is being held by a skeleton : ownerTransform = skeleton's transform
    public Transform ownerTransform;

    //will be assigned to whichever transform needs to be "targeted" by another script, and it's undeterminable which one it will be (owner, object, my)
    public Transform targetTransform;

    //wherever the camera may be - limited to only if the camera is within the same tree, whether higher or deeper
    public Camera camera;
}

public interface IInteractable
{
    void Interact(GameObject interactor);
}

public interface ITakeDamage
{
    void TakeDamage(Item item);
}

public interface IKnockbackable
{
    void GetKnockedBack(Vector3 force);
}

public interface IAbilities
{
    void PrimaryIn();
    void PrimaryOut();

    void SecondaryIn();
    void SecondaryOut();

    void TertiaryIn();
    void TertiaryOut();    
}
