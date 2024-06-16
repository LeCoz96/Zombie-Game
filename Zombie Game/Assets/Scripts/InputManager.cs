using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput _playerInput;
    public PlayerInput.OnFootActions OnFoot;

    private PlayerMotor _motor;
    private PlayerLook _look;

    void Awake()
    {
        _playerInput = new PlayerInput();
        OnFoot = _playerInput.OnFoot;

        _motor = GetComponent<PlayerMotor>();
        _look = GetComponent<PlayerLook>();

        OnFoot.Jump.performed += ctx => _motor.Jump();
        OnFoot.Crouch.performed += ctx => _motor.Crouch();
        OnFoot.Sprint.performed += ctx => _motor.Sprint();
    }

    void FixedUpdate()
    {
        _motor.ProcessMove(OnFoot.Movement.ReadValue<Vector2>());
    }

    private void LateUpdate()
    {
        _look.ProcessLook(OnFoot.Look.ReadValue<Vector2>());
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
