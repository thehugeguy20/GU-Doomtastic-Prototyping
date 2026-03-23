using System.Collections.Generic;
using UnityEngine;

public abstract class DependencyHandler : MonoBehaviour
{
    [SerializeField] protected List<GameObject> parts;

    [SerializeField] protected GameObject host;

    internal Dependencies deps;

    public void InjectDependents()
    {
        foreach (var obj in parts)
        {
            foreach (var script in obj.GetComponents<IHasDependencies>())
            {
                Debug.Log("setting dependencies for:" + script.ToString());
                Debug.Log("for real");
                script.SetDependencies(deps);
            }
        }
    }

    void Start()
    {
        InjectDependents();
    }
}
