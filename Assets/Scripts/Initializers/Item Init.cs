using UnityEngine;

public class ItemInit : DependencyHandler
{
    public Item item;
    
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
