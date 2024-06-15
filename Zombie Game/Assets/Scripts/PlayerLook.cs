using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    private float _xRotation;

    [SerializeField] private float xSesitivity;
    [SerializeField] private float ySesitivity;

    [SerializeField] private float _cameraMin;
    [SerializeField] private float _cameraMax;

    public void ProcessLook(Vector2 input)
    {
        float mouseX = input.x;
        float mouseY = input.y;

        _xRotation -= (mouseY * Time.deltaTime) * ySesitivity;
        _xRotation = Mathf.Clamp(_xRotation, _cameraMin, _cameraMax);

        _camera.transform.localRotation = Quaternion.Euler(_xRotation, 0, 0);
        transform.Rotate(Vector3.up * (mouseX * Time.deltaTime) * xSesitivity);
    }
}
