using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerCharacter playerCharacter;
    [SerializeField] private PlayerCamera playerCamera;
    [SerializeField] private CameraSpring cameraSpring;
    [SerializeField] private CameraLean cameraLean;

    private PlayerInputActions inputActions;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        inputActions = new PlayerInputActions();
        inputActions.Enable();

        playerCharacter.Initialize();
        playerCamera.Initialize(playerCharacter.GetCameraTarget());

        cameraSpring.Initlialize();
        cameraLean.Initialize();
    }

    void OnDestroy()
    {
        inputActions.Dispose();
    }

    void Update()
    {
        var input = inputActions.Gameplay;

        // get camera input and update it's rotation
        var cameraInput = new CameraInput { Look = input.Look.ReadValue<Vector2>() };
        playerCamera.UpdateRotation(cameraInput);

        // get character input and update it
        var characterInput = new CharacterInput
        {
            rotation = playerCamera.transform.rotation,
            move = input.Move.ReadValue<Vector2>()
        };
        playerCharacter.UpdateInput(characterInput);
    }

    void LateUpdate()
    {
        Transform cameraTarget = playerCharacter.GetCameraTarget();
        float deltaTime = Time.deltaTime;
        CharacterState state = playerCharacter.GetState();

        playerCamera.UpdatePosition(cameraTarget);
        cameraSpring.UpdateSpring(deltaTime, cameraTarget.up);
        cameraLean.UpdateLean(deltaTime, state.acceleration, cameraTarget.up);
    }
}
