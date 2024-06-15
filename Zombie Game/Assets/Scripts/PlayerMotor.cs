using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController _controller;
    private Vector3 _playerVelocity;
    [SerializeField] private float _speed;

    private bool _isGrounded;
    private float _gravity = -9.8f;
    [SerializeField] private float _jumpHeight;

    void Start()
    {
        _controller = GetComponent<CharacterController>();   
    }

    void Update()
    {
        _isGrounded = _controller.isGrounded;
    }

    public void ProcessMove(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        _controller.Move(transform.TransformDirection(moveDirection) * _speed * Time.deltaTime);

        _playerVelocity.y += _gravity * Time.deltaTime;
        if (_isGrounded && _playerVelocity.y < 0)
        {
            _playerVelocity.y = -2f;
        }
        _controller.Move(_playerVelocity * Time.deltaTime);
        Debug.Log(_playerVelocity.y);
    }

    public void Jump()
    {
        if(_isGrounded)
        {
            _playerVelocity.y = Mathf.Sqrt(_jumpHeight * -3.0f * _gravity);
        }
    }
}
