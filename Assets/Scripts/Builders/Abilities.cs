using System.Collections.Generic;
using UnityEngine;

public abstract class Abilities : MonoBehaviour, IAbilities
{
    private readonly PlayerInputActions inputActions;

    protected void RunAbilities()
    {
        // PlayerInputActions.GameplayActions input = inputActions.Gameplay;

        // if (input.RightHandPrimary.WasPressedThisFrame()) {RightPrimaryIn();}
        // if (input.RightHandPrimary.WasReleasedThisFrame()) {RightPrimaryOut();}

        // if (input.RightHandSecondary.WasPressedThisFrame()) {RightSecondaryIn();}
        // if (input.RightHandSecondary.WasReleasedThisFrame()) {RightSecondaryOut();}

        // if (input.RightHandPrimary.WasPressedThisFrame()) {LeftPrimaryIn();}
        // if (input.RightHandPrimary.WasReleasedThisFrame()) {LeftPrimaryOut();}

        // if (input.RightHandSecondary.WasPressedThisFrame()) {LeftSecondaryIn();}
        // if (input.RightHandSecondary.WasReleasedThisFrame()) {LeftPrimaryOut();}
    }

    virtual public void RightPrimaryIn() {}
    virtual public void RightPrimaryOut() {}

    virtual public void RightSecondaryIn() {}
    virtual public void RightSecondaryOut() {}

    virtual public void LeftPrimaryIn() {}
    virtual public void LeftPrimaryOut() {}

    virtual public void LeftSecondaryIn() {}
    virtual public void LeftSecondaryOut() {}
}
