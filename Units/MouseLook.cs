using System;
using System.Collections;
using System.Collections.Generic;
using D2D;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] private float _mouseSensitivity = 100f;
    [SerializeField] private Transform _playerBody;
    
    private float _xRotation;

    private void Update()
    {
        var mouseX = Input.GetAxis("Mouse X");
        var mouseY = Input.GetAxis("Mouse Y");
        var mouseSwift = new Vector2(mouseX, mouseY) * _mouseSensitivity * Time.deltaTime;
        
        _xRotation -= mouseSwift.y;
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);
        
        transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
        _playerBody.Rotate(Vector3.up * mouseSwift.x);
    }
}
