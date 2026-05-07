using UnityEditor.Toolbars;
using UnityEngine;

public class CameraSpring : MonoBehaviour
{
    // how long it takes before the strength of the oscillation is halved (over and over until it becomes a tiny number)
    [Min(0.01f)]
    [SerializeField] private float halfLife = 0.075f;
    // how quickly the spring resonates
    [SerializeField] private float frequency = 18f;

    // these handle how much the spring offsets the camera's rotation vs it's position
    [SerializeField] private float angularDispacement = 2f;
    [SerializeField] private float linearDisplacement = 0.05f;

    // pos and velocity of spring
    private Vector3 springPosition;
    private Vector3 springVelocity;

    public void Initlialize()
    {
        springPosition = transform.position;
        springVelocity = Vector3.zero;
    }

    public void UpdateSpring(float deltaTime, Vector3 up)
    {   // set local pos of spring to 0 (safety)
        transform.localPosition = Vector3.zero;

        // make the spring do the spring
        Spring(ref springPosition, ref springVelocity, transform.position, halfLife, frequency, deltaTime);

        // get the spring's local position via difference between spring's simulated position and actual transform position 
        Vector3 localSpringPosition = springPosition - transform.position;

        // height of spring equals the dot product of the spring's local position and a given up vector, (so we know how far above or below the camera target the spring is)
        float springHeight = Vector3.Dot(localSpringPosition, up);

        // offset the transform's local pitch
        transform.localEulerAngles = new Vector3(-springHeight * angularDispacement, 0f, 0f);
        transform.localPosition = localSpringPosition * linearDisplacement;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, springPosition);
        Gizmos.DrawSphere(springPosition, 0.1f);
    }

    // https://allenchou.net/2015/04/game-math-more-on-numeric-springing/
    private static void Spring(ref Vector3 current, ref Vector3 velocity, Vector3 target, float halfLife, float frequency, float timeStep)
    {
        float dampingRatio = -Mathf.Log(0.5f) / (frequency * halfLife);
        float f = 1.0f + 2.0f * timeStep * dampingRatio * frequency;
        float oo = frequency * frequency;
        float hoo = timeStep * oo;
        float hhoo = timeStep * hoo;
        float detInv = 1.0f / (f + hhoo);
        Vector3 detX = f * current + timeStep * velocity + hhoo * target;
        Vector3 detV = velocity + hoo * (target - current);
        
        current = detX * detInv;
        velocity = detV * detInv;
    }
}
