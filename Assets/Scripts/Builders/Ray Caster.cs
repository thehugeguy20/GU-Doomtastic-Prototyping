using Sirenix.OdinInspector;
using UnityEngine;

public class RayCaster : MonoBehaviour
{
    public enum FindType { LineForward, SphereForward }

    [SerializeField] private float distance;

    private Transform camTransform => transform.root.GetComponentInChildren<Camera>().transform;

    public RaycastHit Cast(FindType findType)
    {
        //
        if (findType == FindType.LineForward)
        {
            Ray ray = new(camTransform.position, camTransform.forward);
            Physics.Raycast(ray, out RaycastHit hitInfo, distance);

            return hitInfo;
        }
        else if (findType == FindType.SphereForward)
        {
            Ray ray = new(camTransform.position, camTransform.forward);
            Physics.SphereCast(ray, distance,  out RaycastHit hitInfo, distance);
            
            return hitInfo;
        }
        else
        {
            Ray temp = new(camTransform.position, camTransform.forward);
            Physics.Raycast(temp, out RaycastHit tempHitInfo, distance);

            return tempHitInfo;
        }
    }
}
