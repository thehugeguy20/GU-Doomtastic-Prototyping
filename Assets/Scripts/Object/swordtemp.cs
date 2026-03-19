using UnityEditor;
using UnityEngine;

public class swordtemp : MonoBehaviour
{
    [SerializeField] protected ObjectStateManager manager;
    [SerializeField] private GameObject sword;
    [SerializeField] private GameObject holder;

    void Start()
    {
        sword.GetComponentInChildren<DependencyHandler>().DependencyInjection(holder);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            manager.state.ChangeState(manager.FindState("PullBack"));
        }
        if (Input.GetMouseButtonUp(0))
        {
            manager.state.ChangeState(manager.FindState("Swing"));
        }
    }
}
