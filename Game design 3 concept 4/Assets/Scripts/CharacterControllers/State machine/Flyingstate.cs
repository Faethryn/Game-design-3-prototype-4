using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Flyingstate : BaseState
{
    
    [SerializeField]
    private CharacterStateMachine _CSM;
    public Flyingstate(CharacterStateMachine stateMachine) : base("Moving", stateMachine)
    {
        _CSM = stateMachine;
    }
    [SerializeField] private float speed = 30f;

    public CharacterController playerController;
    public Transform cam;

    [SerializeField] private float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    private bool _appliedGravity = false;

    public Vector3 velocity;
    [SerializeField] private Vector3 _maxVelocity;
    [SerializeField] private bool _speedlimit;

    [SerializeField] private float _dragOnGround;
    [SerializeField] private float _minimumSpeed;

    [SerializeField] private float _downwardMovement;

    [SerializeField] private GameObject _glider;
    public override void Enter()
    {
        base.Enter();
        _glider.GetComponent<MeshRenderer>().enabled = true;

    }
    public override void UpdateLogic()
    {
        base.UpdateLogic();
        GroundTrasition();
        ClimbingTransition();
    }

    private void GroundTrasition()
    {
        if (playerController.isGrounded || Input.GetButtonDown("Jump"))
        {
            _CSM.ChangeState(_CSM.MovingState);
        }
        

    }

    private void ClimbingTransition()
    {

        if (Physics.Raycast(_CSM.transform.position, _CSM.transform.forward, out var hitInfo, .7f))
        {
            _CSM.transform.position = hitInfo.point;


            float angle = Mathf.Atan2(-hitInfo.normal.x, -hitInfo.normal.z) * Mathf.Rad2Deg;
            _CSM.transform.rotation = Quaternion.Euler(0f, angle, 0f);

            _CSM.ClimbingState.JumpForce = _CSM.MovingState.JumpForce;
            _CSM.ChangeState(_CSM.ClimbingState);
        }
    }

    #region movement and physics
    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
        ApplyGravity();
        
        ApplyAirDrag();
       
        LimitSpeed();
        AirMovement();
       
        MovementStabilize();

    }

    private void ApplyGravity()
    {
        if (!playerController.isGrounded && _appliedGravity == false)
        {


            velocity.y += _downwardMovement * Physics.gravity.y * Time.fixedDeltaTime;
            if(velocity.y <= (_downwardMovement * Physics.gravity.y * Time.fixedDeltaTime) && _appliedGravity == false)
            {
                _appliedGravity = true;
                velocity.y = _downwardMovement * Physics.gravity.y * Time.fixedDeltaTime;

            }
               
           

        }

    }
   
    private void ApplyAirDrag()
    {
        float ystorage = velocity.y;
        
            velocity = velocity * (1 - Time.deltaTime * _dragOnGround);
        velocity.y = ystorage;
      
    }

    private void LimitSpeed()
    {
        if (_speedlimit)
        {
            velocity = new Vector3(Mathf.Clamp(velocity.x, -_maxVelocity.x, _maxVelocity.x), velocity.y, Mathf.Clamp(velocity.z, -_maxVelocity.z, _maxVelocity.z));
        }
    }

    private void AirMovement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(_CSM.transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            _CSM.transform.rotation = Quaternion.Euler(0f, angle, 0f);

            //Rotation(direction);
            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            //playerController.Move(moveDirection.normalized * speed * Time.deltaTime);
            velocity += moveDirection.normalized * speed * Time.deltaTime;



        }
        playerController.Move(velocity * Time.deltaTime);
    }

    private void MovementStabilize()
    {
        if (Mathf.Abs(velocity.x) > _minimumSpeed && Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
        {
            velocity.x = 0;

        }
        if (Mathf.Abs(velocity.z) > _minimumSpeed && Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
        {
            velocity.z = 0;
        }





    }

    #endregion

    public override void Exit()
    {
        _glider.GetComponent<MeshRenderer>().enabled = false;
        velocity = new Vector3(0, 0, 0);
        _appliedGravity = false;
        base.Exit();
    }


}
