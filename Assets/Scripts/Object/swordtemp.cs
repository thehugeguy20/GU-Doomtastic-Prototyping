using UnityEditor;
using UnityEngine;

public class swordtemp : Abilities
{
    [SerializeField] protected ObjectStateManager manager;
    [SerializeField] private GameObject sword;
    [SerializeField] private GameObject parent;

    void Start()
    {
        // sword.GetComponentInChildren<DependencyHandler>().DependencyInjection(parent);
    }

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
