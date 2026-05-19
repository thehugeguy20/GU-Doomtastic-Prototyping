using Sirenix.OdinInspector;
using UnityEngine;

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
    void RightPrimaryIn();
    void RightPrimaryOut();

    void RightSecondaryIn();
    void RightSecondaryOut();

    void LeftPrimaryIn();
    void LeftPrimaryOut();

    void LeftSecondaryIn();
    void LeftSecondaryOut();
   
}
