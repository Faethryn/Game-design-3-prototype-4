using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeceleratingFPScontroller : MonoBehaviour
{
    [SerializeField] private CharacterController playerController;
    [SerializeField] private float speed ;

    [SerializeField] private Vector3 _velocity;
    [SerializeField] private Vector3 _maxVelocity;
    [SerializeField]
    [Range(0.5f, 100f)]
    private float _jumpHeight;
    private Vector3 _jumpForce;
    private bool _jump;
    [SerializeField] private bool _speedlimit;

    [SerializeField] private float _dragOnGround ;


    // Start is called before the first frame update
    void Start()
    {
        _jumpForce = -Physics.gravity.normalized * Mathf.Sqrt(2 * Physics.gravity.magnitude * _jumpHeight);
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    _jump = true;
        //}

        ApplyGravity();
        ApplyGround();
        ApplyGroundDrag();
        ApplyJump();
        LimitSpeed();
        GroundMovement(move);

    }

    private void LimitSpeed()
    {
       if(_speedlimit)
        {
        _velocity = new Vector3(Mathf.Clamp(_velocity.x, -_maxVelocity.x, _maxVelocity.x), _velocity.y, Mathf.Clamp(_velocity.z, -_maxVelocity.z, _maxVelocity.z));
        }
    }

    private void GroundMovement(Vector3 moving)
    {
        _velocity += moving * speed * Time.deltaTime;

        playerController.Move(_velocity * Time.deltaTime);
    }

    private void ApplyGroundDrag()
    {
        if (playerController.isGrounded)
        {
            _velocity = _velocity * (1 - Time.deltaTime * _dragOnGround);

        }
    }


    private void ApplyGround()
    {
        if (playerController.isGrounded)
        {
            _velocity -= Vector3.Project(_velocity, Physics.gravity.normalized);
        }
    }

    private void ApplyJump()
    {
        if (Input.GetButton("Jump") && playerController.isGrounded)
        {
            _velocity += _jumpForce;

        }

    }

    private void ApplyGravity()
    {
        if (!playerController.isGrounded)
        {
            _velocity += Physics.gravity * Time.fixedDeltaTime;

        }

    }
}
