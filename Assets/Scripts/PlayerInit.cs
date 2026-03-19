using NUnit.Framework;
using Sirenix.OdinInspector;
using UnityEngine;

public class PlayerInit : DependencyHandler
{
    [SerializeField] private GameObject player;

    public override void DependencyInjection(GameObject host)
    {
        var deps = new Dependencies
        {
            transform = host.transform,
            camera = host.GetComponentInChildren<Camera>(),
        };

        foreach (var req in host.GetComponentsInChildren<IHasDependencies>())
        {
            req.SetDependencies(deps);
            Debug.Log("setting dependency for" + req);
        }
    }

    void Start()
    {
        Debug.Log("hello");
        DependencyInjection(player);
    }
}
