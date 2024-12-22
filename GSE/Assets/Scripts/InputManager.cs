using UnityEngine;
using UnityEngine.InputSystem;


public class NewMonoBehaviourScript : MonoBehaviour
{
    private PlayerInput playerInput;
    private PlayerInput.OnFootActions OnFoot;
    
    private PlayerMotor motor;
    private PlayerLook look;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        playerInput = new PlayerInput();
        OnFoot = playerInput.OnFoot;
        motor = GetComponent<PlayerMotor>();
        look = GetComponent<PlayerLook>();
        OnFoot.Jump.performed += ctx => motor.Jump();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //tell the PlayerMotor to move using the value from our movement action
        motor.ProcessMove(OnFoot.Movement.ReadValue<Vector2>());
    }

        void LateUpdate()
    {
        //tell the PlayerMotor to move using the value from our movement action
        look.ProcessLook(OnFoot.Look.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        OnFoot.Enable();
    }
    private void OnDisable()
    {
        OnFoot.Disable();
    }
}
