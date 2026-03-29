using KinematicCharacterController;
using UnityEngine;

public struct CharacterInput
{
    public Quaternion rotation;
    public Vector2 move;
}

public struct CharacterState
{
    public Vector3 acceleration;
    public Vector3 velocity;
}

public class PlayerCharacter : MonoBehaviour, ICharacterController
{

    [SerializeField] private KinematicCharacterMotor motor;
    [SerializeField] private Transform cameraTarget;
    [SerializeField] private float walkSpeed = 20f;
    [SerializeField] private float gravity = -90f;
    [SerializeField] private float walkResponse;
    [SerializeField] private float airSpeed = 1.5f;
    [SerializeField] private float airAcceleration = 70f;
    private CharacterState state = new();
    private CharacterState lastState;
    private CharacterState tempState;


    private Quaternion _requestedRotation;
    private Vector3 _requestedMovement;

    public void Initialize()
    {
        motor.CharacterController = this;
        lastState = state;
    }

    public void UpdateInput(CharacterInput input)
    {
        _requestedRotation = input.rotation;

        // take the 2d input vector and craate a 3d movement vector on the xz plane
        _requestedMovement = new Vector3(input.move.x, 0f, input.move.y);

        // clamp the length of the vector to 1 so you don't move farther/faster when going diagonally (since the plane is a square, and the line from the middle of the square to a corner is a longer line than one that doesn't)
        _requestedMovement = Vector3.ClampMagnitude(_requestedMovement, 1f);

        // orient movement so that it's relative to the direction the player is facing
        _requestedMovement = input.rotation * _requestedMovement;
    }

    public void AfterCharacterUpdate(float deltaTime)
    {
        lastState = tempState;
    }

    public void BeforeCharacterUpdate(float deltaTime)
    {
        tempState = state;
    }

    public bool IsColliderValidForCollisions(Collider coll)
    {
        return true;
    }

    public void OnDiscreteCollisionDetected(Collider hitCollider)
    {
        return;
    }

    public void OnGroundHit(Collider hitCollider, Vector3 hitNormal, Vector3 hitPoint, ref HitStabilityReport hitStabilityReport)
    {
        
    }

    public void OnMovementHit(Collider hitCollider, Vector3 hitNormal, Vector3 hitPoint, ref HitStabilityReport hitStabilityReport)
    {
        state.acceleration = Vector3.ProjectOnPlane(state.acceleration, hitNormal);
    }

    public void PostGroundingUpdate(float deltaTime)
    {
        
    }

    public void ProcessHitStabilityReport(Collider hitCollider, Vector3 hitNormal, Vector3 hitPoint, Vector3 atCharacterPosition, Quaternion atCharacterRotation, ref HitStabilityReport hitStabilityReport)
    {
        
    }

    public void UpdateRotation(ref Quaternion currentRotation, float deltaTime)
    {
        // update character rotation to face the same direction as the camera rotation

        //the camera's rotation is flattened by being projected onto a flat plane so that when you look up and down with the camera the  rotation doesn't tilt/pitch the entire character up and down too
        var forward = Vector3.ProjectOnPlane
        (
            _requestedRotation * Vector3.forward,
            motor.CharacterUp
        );

        if (forward != Vector3.zero)
        {
            currentRotation = Quaternion.LookRotation(forward, motor.CharacterUp);
        }
    
    }

    public void UpdateVelocity(ref Vector3 currentVelocity, float deltaTime)
    {
        state.acceleration = Vector3.zero;

        // if on the ground
        if (motor.GroundingStatus.IsStableOnGround)
        {
            // snap movement direction to the angle of the surface the character is walking on (ramps!)
            var groundedMovement = motor.GetDirectionTangentToSurface
            (
                direction: _requestedMovement,
                surfaceNormal: motor.GroundingStatus.GroundNormal
            ) * _requestedMovement.magnitude;

            float speed = walkSpeed;
            float response = walkResponse;

            // and smoothly move along the ground in that direction
            Vector3 targetVelocity = groundedMovement * speed;
            Vector3 moveVelocity = Vector3.Lerp
            (
                a: currentVelocity,
                b: targetVelocity,
                t: 1f - Mathf.Exp(-response * deltaTime)
            );

            state.velocity = moveVelocity;
            state.acceleration = (moveVelocity - currentVelocity) / deltaTime;
            currentVelocity = moveVelocity;
        }
        // if not on the ground (in the air)
        else
        {
            //move
            if (_requestedMovement.sqrMagnitude > 0f)
            {
                // movement is projected onto a movement plane (aka planar)
                Vector3 planarMovement = Vector3.ProjectOnPlane
                (
                    vector: _requestedMovement,
                    planeNormal: motor.CharacterUp
                ) * _requestedMovement.magnitude;

                // current velocity on momvement plane

                Vector3 currentPlanarVelocity = Vector3.ProjectOnPlane
                (
                    vector: currentVelocity,
                    planeNormal: motor.CharacterUp
                );

                // calculate movement force
                Vector3 movementForce = planarMovement * airAcceleration * deltaTime;

                // add to current planar velocity for a target velocity
                Vector3 targetPlanarVelocity = currentPlanarVelocity + movementForce;

                // limit target velocity to air speed
                targetPlanarVelocity = Vector3.ClampMagnitude(targetPlanarVelocity, airSpeed);

                // steer towards current velocity
                currentVelocity += targetPlanarVelocity - currentPlanarVelocity;
            }

            // gravity
            float effectiveGravity = gravity;
            currentVelocity += motor.CharacterUp * gravity * deltaTime;
            float verticalSpeed = Vector3.Dot(currentVelocity, motor.CharacterUp);
            
            currentVelocity += motor.CharacterUp * effectiveGravity * deltaTime;

            state.velocity = currentVelocity;
        }

    }

    public Transform GetCameraTarget() => cameraTarget;

    public CharacterState GetState() => state;
}
