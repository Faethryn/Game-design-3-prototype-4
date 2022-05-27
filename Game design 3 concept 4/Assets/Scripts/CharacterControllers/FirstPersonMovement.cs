using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FirstPersonMovement : MonoBehaviour
{
    [SerializeField] private CharacterController playerController;
    [SerializeField] private float speed = 12f;
    private Vector3 _velocity;

    [SerializeField]
    [Range(0.5f, 100f)]
    private float _jumpHeight;
    private Vector3 _jumpForce;
    private bool _jump = false;

    [SerializeField]
    private PlayerInput _playerInput;
    

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        _jumpForce = -Physics.gravity.normalized * Mathf.Sqrt(2 * Physics.gravity.magnitude * _jumpHeight);
        _playerInput = FindObjectOfType<GameLoop>().PlayerInput;


    }

    // Update is called once per frame
    void Update()
    {
        float x = _playerInput.Player.Movement.ReadValue<Vector2>().x;
        float z = _playerInput.Player.Movement.ReadValue<Vector2>().y;
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
        if (_playerInput.Player.Jump.ReadValue<float>() > 0 && playerController.isGrounded)
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
