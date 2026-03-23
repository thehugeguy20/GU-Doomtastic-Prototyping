using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class swordtemp : Abilities
{
    [SerializeField] protected ItemStateManager manager;
    [SerializeField] private GameObject sword;
    [SerializeField] private GameObject parent;

    void Update()
    {
        RunAbilities();
    }

    public override void PrimaryIn()
    {
        manager.state.ChangeState(manager.FindState("PullBack"));
    }
    public override void PrimaryOut()
    {
        manager.state.ChangeState(manager.FindState("Swing"));
    }
}
