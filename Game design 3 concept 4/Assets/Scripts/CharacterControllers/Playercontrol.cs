using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Playercontrol : MonoBehaviour
{
    [SerializeField]
    private CharacterController _characterController = null;
    private Vector3 _velocity;
    private bool _jump;

    [SerializeField]
    [Range(0.5f, 5f)]
    private float _jumpHeight = 2;
    private Vector3 _jumpForce;

    private Vector3 _movement;
    private float _speed = 5;

    private float _dragOnGround =5f;



    void Start()
    {
        _jumpForce = -Physics.gravity.normalized * Mathf.Sqrt(2 * Physics.gravity.magnitude * _jumpHeight);
    }

    // Update is called once per frame
    void Update()
    {
        _movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            _jump = true;

        }
    }

    private void FixedUpdate()
    {
        ApplyGravity();
        ApplyGround();
        ApplyMovement();
        ApplyGroundDrag();
        ApplyRotation();
        ApplyJump();
        _characterController.Move(_velocity * Time.fixedDeltaTime);
    }
    private void ApplyRotation()
    {
        if (_characterController.isGrounded)
        {
            Vector3 forward = Vector3.Scale(_velocity, new Vector3(1, 0, 1));
            if (forward.normalized.sqrMagnitude <= Mathf.Epsilon) return;
            Vector3 xzAbsoluteForward = forward;
            Quaternion forwardRotation = Quaternion.LookRotation(xzAbsoluteForward.normalized);
            this.transform.rotation = forwardRotation;
        }

    }
    private void ApplyGroundDrag()
    {
        if (_characterController.isGrounded)
        {
            _velocity = _velocity * (1 - Time.deltaTime * _dragOnGround);

        }
    }

    private void ApplyMovement()
    {
        if (_characterController.isGrounded)
        {
            Vector3 forward = Vector3.forward;
            Vector3 xzAbsoluteForward = Vector3.Scale(forward, new Vector3(1, 0, 1));
            Quaternion forwardRotation = Quaternion.LookRotation(xzAbsoluteForward);
            Vector3 relativeMovement = forwardRotation * _movement;
            _velocity += relativeMovement * _speed * Time.fixedDeltaTime;

        }
    }

    private void ApplyGround()
    {
        if(_characterController.isGrounded)
        {
            _velocity -= Vector3.Project(_velocity, Physics.gravity.normalized);
        }
    }

    private void ApplyJump()
    {
        if(_jump && _characterController.isGrounded)
        {
            _velocity +=  _jumpForce;
            _jump = false;
        }

    }

    private void ApplyGravity()
    {
        if(!_characterController.isGrounded )
        {
            _velocity += Physics.gravity * Time.fixedDeltaTime;

        }

    }
}
