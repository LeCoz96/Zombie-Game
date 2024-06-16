using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController _controller;
    private Vector3 _playerVelocity;
    [SerializeField] private float _crouchSpeed;
    [SerializeField] private float _walkSpeed;
    [SerializeField] private float _sprintSpeed;
    private float _speed;

    private bool _isGrounded;
    private float _gravity = -9.8f;
    [SerializeField] private float _jumpHeight;

    private bool _lerpCrouch;
    private bool _isCrouching;
    private bool _isSprinting;
    [SerializeField] private float _crouchTimer;

    void Start()
    {
        _controller = GetComponent<CharacterController>();

        _speed = _walkSpeed;
    }

    void Update()
    {
        _isGrounded = _controller.isGrounded;

        if (_lerpCrouch)
        {
            _crouchTimer += Time.deltaTime;
            float timer = _crouchTimer / 1.0f;
            timer *= timer;

            if (_isCrouching)
            {
                _controller.height = Mathf.Lerp(_controller.height, 1, timer);
            }
            else
            {
                _controller.height = Mathf.Lerp(_controller.height, 2, timer);
            }

            if (timer > 1)
            {
                _lerpCrouch = false;
                _crouchTimer = 0.0f;
            }
        }

        Debug.Log(_speed);
    }

    public void ProcessMove(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        _controller.Move(transform.TransformDirection(moveDirection) * _speed * Time.deltaTime);

        _playerVelocity.y += _gravity * Time.deltaTime;
        if (_isGrounded && _playerVelocity.y < 0.0f)
        {
            _playerVelocity.y = -2.0f;
        }
        _controller.Move(_playerVelocity * Time.deltaTime);
        //Debug.Log(_playerVelocity.y);
    }

    public void Jump()
    {
        if(_isGrounded)
        {
            _playerVelocity.y = Mathf.Sqrt(_jumpHeight * -3.0f * _gravity);
        }
    }

    public void Crouch()
    {
        _isCrouching = !_isCrouching;
        _crouchTimer = 0.0f;
        _lerpCrouch = true;

        if (_isCrouching)
        {
            _speed = _crouchSpeed;
        }
        else
        {
            _speed = _walkSpeed;
        }
    }

    public void Sprint()
    {
        _isSprinting = !_isSprinting;

        if (_isSprinting )
        {
            _speed = _sprintSpeed;
        }
        else
        {
            _speed = _walkSpeed;
        }
    }
}
