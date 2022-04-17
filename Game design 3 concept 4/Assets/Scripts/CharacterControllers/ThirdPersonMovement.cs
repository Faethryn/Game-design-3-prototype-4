using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    [SerializeField] private float speed = 6f;

    public CharacterController playerController;
    public Transform cam;

    [SerializeField] private float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    [SerializeField]
    [Range(0.5f, 100f)]
    private float _jumpHeight;
    private Vector3 _jumpForce;
    private bool _jump;
    private Vector3 _velocity;

    private void Start()
    {
        _jumpForce = -Physics.gravity.normalized * Mathf.Sqrt(2 * Physics.gravity.magnitude * _jumpHeight);
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space) && playerController)
        //{
        //    _jump = true;
        //}
        ApplyGravity();
        ApplyGround();
        ApplyJump();
        GroundMovement();
        
    }

    private void GroundMovement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            //Rotation(direction);
            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            playerController.Move(moveDirection.normalized * speed * Time.deltaTime);
            
        }
        playerController.Move(_velocity * Time.deltaTime);
    }

    //private void Rotation(Vector3 InputDirection)
    //{
    //    float targetAngle = Mathf.Atan2(InputDirection.x, InputDirection.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
    //    float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
    //    transform.rotation = Quaternion.Euler(0f, angle, 0f);

    //}

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
