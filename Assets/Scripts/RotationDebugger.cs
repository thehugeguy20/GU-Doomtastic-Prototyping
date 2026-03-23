using UnityEngine;

public class RotationDebugger : MonoBehaviour
{
    private Quaternion lastRotation;

    void Start()
    {
        lastRotation = transform.localRotation;
    }

    void Update()
    {
        if (transform.localRotation != lastRotation)
        {
            Debug.Log("Rotation changed to: " + transform.localRotation.eulerAngles);
            lastRotation = transform.localRotation;
            Debug.Break(); // pauses the editor automatically
        }
    }
}