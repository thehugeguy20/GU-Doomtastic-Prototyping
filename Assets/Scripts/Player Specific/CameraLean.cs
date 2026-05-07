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

        // if planar accel is greater than the damped accel, the damping we use is the attackDamping, if not, we use decayDamping
        float damping = planarAcceleration.magnitude > dampedAcceleration.magnitude
            ? attackDmaping
            : decayDamping;

        // https://docs.unity3d.com/6000.3/Documentation/ScriptReference/Vector3.SmoothDamp.html
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

        // align local rotation with world axis
        transform.localRotation = Quaternion.identity;

        // create a rotation based on the angle given by multiplying our own rotation by the magnitude of damped acceleration * strength when applied to the lean axis
        transform.rotation = Quaternion.AngleAxis(dampedAcceleration.magnitude * strength, leanAxis) * transform.rotation;
    }
}
