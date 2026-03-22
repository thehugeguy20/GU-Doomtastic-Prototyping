using UnityEngine;

public class ItemInit : DependencyHandler
{
    void Awake()
    {
        deps = new()
        {
            objectTransform = host.transform,
            targetTransform = host.transform,
            camera = host.GetComponentInChildren<Camera>(),        
        };
    }
}
