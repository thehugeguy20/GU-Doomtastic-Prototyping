using UnityEngine;

public class CameraLean : MonoBehaviour
{
    [SerializeField] private float attackDmaping = 0.5f;
    [SerializeField] private float decayDamping = 0.3f;
    [SerializeField] private float strength = 0.075f;

    private Vector3 dampedAcceleration;
    private Vector3 dampedAccelerationVel;

    public void Initialize()
    {
        
    }

    public void UpdateLean(float deltaTime, Vector3 acceleration, Vector3 up)
    {
        Vector3 planarAcceleration = Vector3.ProjectOnPlane(acceleration, up);
        float damping = planarAcceleration.magnitude > dampedAcceleration.magnitude
            ? attackDmaping
            : decayDamping;

        dampedAcceleration = Vector3.SmoothDamp
        (
            current: dampedAcceleration,
            target: planarAcceleration,
            currentVelocity: ref dampedAccelerationVel,
            smoothTime: damping,
            maxSpeed: float.PositiveInfinity,
            deltaTime: deltaTime
        );

        // get rotation axis based on acceleration vector
        Vector3 leanAxis = Vector3.Cross(dampedAcceleration.normalized, up).normalized;

        transform.localRotation = Quaternion.identity;

        transform.rotation = Quaternion.AngleAxis(dampedAcceleration.magnitude * strength, leanAxis) * transform.rotation;

        Debug.DrawRay(transform.position, acceleration, Color.red);
        Debug.DrawRay(transform.position, dampedAcceleration, Color.blue);
    }
}
