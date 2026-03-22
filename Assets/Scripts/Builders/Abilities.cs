using System.Collections.Generic;
using UnityEngine;

public abstract class Abilities : MonoBehaviour, IAbilities
{

    [SerializeField] private KeyCode Primary;
    [SerializeField] private KeyCode Secondary;
    [SerializeField] private KeyCode Tertiary;

    protected void RunAbilities()
    {
        if (Input.GetKeyDown(Primary)) {PrimaryIn();}
        if (Input.GetKeyUp(Primary)) {PrimaryOut();}

        if (Input.GetKeyDown(Secondary)) {SecondaryIn();}
        if (Input.GetKeyUp(Secondary)) {SecondaryOut();}   

        if (Input.GetKeyDown(Tertiary)) {TertiaryIn();}
        if (Input.GetKeyUp(Tertiary)) {TertiaryOut();} 
    }

    virtual public void PrimaryIn() {}
    virtual public void PrimaryOut() {}

    virtual public void SecondaryIn() {}
    virtual public void SecondaryOut() {}

    virtual public void TertiaryIn() {}
    virtual public void TertiaryOut() {}

}
