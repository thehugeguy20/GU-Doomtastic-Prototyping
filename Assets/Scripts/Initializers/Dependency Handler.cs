using NUnit.Framework;
using Sirenix.OdinInspector;
using UnityEngine;

public abstract class DependencyHandler : MonoBehaviour
{
    public virtual void DependencyInjection(GameObject parent)
    {
        var deps = new Dependencies
        {
            
        };

        foreach (var req in GetComponentsInChildren<IHasDependencies>())
        {
            req.SetDependencies(deps);
        }
    }
}
