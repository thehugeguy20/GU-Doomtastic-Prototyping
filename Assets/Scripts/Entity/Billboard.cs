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
