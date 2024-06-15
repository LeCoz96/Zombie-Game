using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Camera cam;

    private float _xRotation;

    public float xSesitivity = 30f;
    public float ySesitivity = 30f;

    public void ProcessLook(Vector2 input)
    {
        float mouseX = input.x;
        float mouseY = input.y;

        _xRotation -= (mouseY * Time.deltaTime) * ySesitivity;
        _xRotation = Mathf.Clamp(_xRotation, -80f, 80f);

        cam.transform.localRotation = Quaternion.Euler(_xRotation, 0, 0);
        transform.Rotate(Vector3.up * (mouseX * Time.deltaTime) * xSesitivity);
    }
}
