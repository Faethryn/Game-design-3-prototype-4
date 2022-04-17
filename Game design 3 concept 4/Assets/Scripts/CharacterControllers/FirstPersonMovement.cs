using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonMovement : MonoBehaviour
{
    [SerializeField] private CharacterController playerController;
    [SerializeField] private float speed = 12f;
    private Vector3 _velocity;

    [SerializeField]
    [Range(0.5f, 100f)]
    private float _jumpHeight;
    private Vector3 _jumpForce;
    private bool _jump;
   
    

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        _jumpForce = -Physics.gravity.normalized * Mathf.Sqrt(2 * Physics.gravity.magnitude * _jumpHeight);
        
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
        ApplyJump();
        GroundMovement(move);

    }

    private void GroundMovement(Vector3 moving)
    {
        playerController.Move(moving * speed * Time.deltaTime);
        playerController.Move(_velocity * Time.deltaTime);
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
