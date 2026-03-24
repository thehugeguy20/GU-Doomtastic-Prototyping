using NUnit.Framework;
using Sirenix.OdinInspector;
using UnityEngine;

public class RayCaster : MonoBehaviour, IHasDependencies
{

    public enum FindType { LineForward, SphereForward }

    public enum FromWhere {Camera, Host, Self}

    [SerializeField] private FindType findType = FindType.SphereForward;

    [SerializeField] private FromWhere fromWhere = FromWhere.Host;

    [SerializeField] private float distance;

    [ShowIf("findType", FindType.SphereForward)]
    [SerializeField] private float sphereRadius;

    public Transform rayOrigin;

    public void SetDependencies(Dependencies deps)
    {
        if (fromWhere == FromWhere.Camera && deps.camera != null)
        {
            rayOrigin = deps.camera.transform;
        }
        else if (fromWhere == FromWhere.Host && deps.targetTransform != null)
        {
            rayOrigin = deps.targetTransform;
        }
        else if (fromWhere == FromWhere.Self)
        {
            rayOrigin = this.transform;
        }
    }

    public RaycastHit Cast()
    {
        if (findType == FindType.LineForward)
        {
            Ray ray = new(rayOrigin.transform.position, rayOrigin.transform.forward);
            Physics.Raycast(ray, out RaycastHit hitInfo, distance);

            return hitInfo;
        }
        else if (findType == FindType.SphereForward)
        {
            Ray ray = new(rayOrigin.position, rayOrigin.forward);
            Physics.SphereCast(ray, distance,  out RaycastHit hitInfo, distance);
            
            return hitInfo;
        }
        else
        {
            Ray temp = new(rayOrigin.position, rayOrigin.forward);
            Physics.Raycast(temp, out RaycastHit tempHitInfo, distance);

            return tempHitInfo;
        }
    }
}
