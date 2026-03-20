using UnityEngine;

public class ItemInit : DependencyHandler
{
    public override void DependencyInjection(GameObject host)
    {
        var deps = new Dependencies
        {
            transform = host.transform,
            camera = host.GetComponentInChildren<Camera>(),
        };

        foreach (var req in GetComponentsInChildren<IHasDependencies>())
        {
            req.SetDependencies(deps);
        }
    }
}
