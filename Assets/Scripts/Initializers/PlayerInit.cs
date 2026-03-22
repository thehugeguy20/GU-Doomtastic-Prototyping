using NUnit.Framework;
using Sirenix.OdinInspector;
using UnityEngine;

public class PlayerInit : DependencyHandler
{
    // [SerializeField] private Transform _objectTransform;
    // private Transform _targetTransform => _objectTransform;

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
