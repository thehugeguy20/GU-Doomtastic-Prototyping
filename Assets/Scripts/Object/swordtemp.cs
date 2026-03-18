using UnityEditor;
using UnityEngine;

public class swordtemp : MonoBehaviour
{
    [SerializeField] protected ObjectStateManager manager;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            manager.state.ChangeState(manager.FindState("PullBack"));
        }
        if (Input.GetKeyUp(KeyCode.X))
        {
            manager.state.ChangeState(manager.FindState("Swing"));
        }
    }
}
