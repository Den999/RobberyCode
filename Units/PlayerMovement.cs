using System;
using System.Collections;
using System.Collections.Generic;
using D2D;
using D2D.Utils;
using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;
    [SerializeField] private Vector3 _crawlScale;
    [SerializeField] private float _crawlSpeedFactor;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _groundCheckRayLength;
    [SerializeField] private float _groundCheckSphereRadius;
    
    private PlayerInput _input;
    private Rigidbody _rigidbody;
    private Vector3 _originalScale;

    private bool CanJump => Physics.SphereCast(new Ray(transform.position, -transform.up), _groundCheckSphereRadius , _groundCheckRayLength);

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _input = GetComponent<PlayerInput>();

        _originalScale = transform.localScale;
    }

    private void FixedUpdate()
    {
        UpdateRotation();
        UpdateMovement();
        UpdateScale();
    }

    private void UpdateRotation()
    {
        // Follow the mouse
        transform.LookAt(GetMousePositionOnXZPlane());
        var rotation = transform.rotation.eulerAngles;
        rotation.x = 0;
        rotation.z = 0;
        transform.rotation = Quaternion.Euler(rotation);
    }
    
    private void UpdateMovement()
    {
        // If walk => set movement speed 
        float speed = _input.forwardKey.IsPressed ? _movementSpeed : 0;
        if (_input.backwardKey.IsPressed)
            speed -= _movementSpeed;

        // Slow down if crawl
        if (_input.CrawlButtonPressed)
            speed *= _crawlSpeedFactor;

        var velocity = _rigidbody.velocity;
        

        // Don`t touch y velocity to avoid "low gravity effect"
        var yVelocity = velocity.y;
        velocity = transform.forward * speed;
        velocity.y = yVelocity;

        if (_input.jumpKey.IsPressed && CanJump)
            velocity.y = _jumpForce;
        
        _rigidbody.velocity = velocity;
    }

    private void UpdateScale()
    {
        transform.localScale = _input.CrawlButtonPressed ? _crawlScale : _originalScale;
    }
    
    // static Plane XZPlane = new Plane(Vector3.up, new Vector3(0, -.6f, 0));
    static Plane XZPlane = new Plane(Vector3.up, new Vector3(0, 1, 0));

    private static Vector3 GetMousePositionOnXZPlane()
    {
        float distance;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(XZPlane.Raycast (ray, out distance)) 
        {
            Vector3 hitPoint = ray.GetPoint(distance);
            //Just double check to ensure the y position is exactly zero
            hitPoint.y = 0;
            return hitPoint;
        }
        return Vector3.zero;
    }

}
