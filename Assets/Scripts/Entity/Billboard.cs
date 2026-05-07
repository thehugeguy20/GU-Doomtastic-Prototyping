using UnityEngine;

public class Billboard : MonoBehaviour
{
    [SerializeField] private BillboardType billboardType;

    public enum BillboardType {LookAtCamera, CameraForward};
    

    void LateUpdate()
    {
        switch (billboardType)
        {
            case BillboardType.LookAtCamera:
                // look at the camera, but not upwards or downwards. only ever forward (because this LookAt is given this object's own y position)
                transform.LookAt(new Vector3
                (
                    Camera.main.transform.position.x,
                    this.transform.position.y,
                    Camera.main.transform.position.z
                ), Vector3.up);
                break;
            case BillboardType.CameraForward:
                transform.forward = Camera.main.transform.forward;
                break;
            default:
                break;
        }
    }
}
