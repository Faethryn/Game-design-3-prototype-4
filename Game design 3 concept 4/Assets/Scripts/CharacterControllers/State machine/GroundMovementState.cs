using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GroundMovementState : BaseState
{
    [SerializeField]
    private CharacterStateMachine _CSM;
    public GroundMovementState(CharacterStateMachine stateMachine) : base("Moving", stateMachine)
    {
        _CSM = stateMachine;
    }


    [SerializeField] private float speed = 30f;

    public CharacterController playerController;
    public Transform cam;

    [SerializeField] private float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    [SerializeField]
    [Range(0.5f, 100f)]
    private float _jumpHeight;
    public Vector3 JumpForce;
    private bool _jump;

    public Vector3 velocity;
    [SerializeField] private Vector3 _maxVelocity;
    [SerializeField] private bool _speedlimit;

    [SerializeField] private float _dragOnGround;
    [SerializeField] private float _minimumSpeed;
    [SerializeField] private float _slideFriction;
   
   //public Vector3 _hitNormal;

    public override void Enter()
    {
        base.Enter();
        JumpForce = -Physics.gravity.normalized * Mathf.Sqrt(2 * Physics.gravity.magnitude * _jumpHeight);

    }
    
    public override void UpdateLogic()
    {
        base.UpdateLogic();

        TransitionCheck();
    }

    #region different transition checks
    private void TransitionCheck()
    {
        //IdleTransition();
        SprintTransition();
        MidAirTransition();

    }

    
    private void MidAirTransition()
    {
       if(!IsGrounded())
       {
           _CSM.MidAirState.velocity = velocity;
           _CSM.ChangeState(_CSM.MidAirState);
       }
    }

    //private void FlyTransition()
    //{
    //    //Need to skip 1 frame for GetButtonDown
    //   if (!_skipFrame)
    //   {
    //       _skipFrame = true;
    //       return;
    //   }
    //   if(!playerController.isGrounded && Input.GetButtonDown("Jump"))
    //   {
    //        _skipFrame = false;
    //        _CSM.FlyState._velocity = _velocity;
    //       _CSM.ChangeState(_CSM.FlyState);
    //   }
    //}

    private void SprintTransition()
    {
        if (Input.GetButton("Sprint"))
        {
            _CSM.SprintState.velocity = velocity;
            _CSM.ChangeState(_CSM.SprintState);
        }
    }


    //private void IdleTransition()
    //{
    //    if (velocity.x < _minimumSpeed && velocity.z < _minimumSpeed && velocity.y < _minimumSpeed && playerController.isGrounded)
    //    {
    //        _CSM.ChangeState(_CSM.IdleState);
    //    }
    //}

    #endregion

    //custom groundcheck, currently uses a raycast
    private bool IsGrounded()
    {
        if (Physics.Raycast(_CSM.transform.position, -_CSM.transform.up, out var hitInfo, 1.2f * _CSM.transform.parent.localScale.y))
        {
            if (!Input.GetButton("Jump"))
            {
                playerController.Move(hitInfo.point - _CSM.transform.position);
            }
            return true;
        }
        return false;
    }

    #region movement and physics

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
       
        ApplyGravity();
        ApplyGround();
        ApplyDrag();
        ApplyJump();
        //SlopeSliding();
        LimitSpeed();
        GroundMovement();
        MovementStabilize();
        
    }

    private void ApplyGravity()
    {
        if (!playerController.isGrounded /*|| !IsGrounded()*/)
        {
            velocity += Physics.gravity * Time.fixedDeltaTime;

        }

    }

    private void ApplyGround()
    {
        if (playerController.isGrounded /*&& IsGrounded()*/)
        {
            velocity -= Vector3.Project(velocity, Physics.gravity.normalized);
        }
    }

    private void ApplyDrag()
    {
            float yVelocity = velocity.y;
            velocity = velocity * (1 - Time.fixedDeltaTime * _dragOnGround);
            velocity.y = yVelocity;
    }

    private void ApplyJump()
    {
        if (Input.GetButton("Jump") && playerController.isGrounded /*&& IsGrounded()*/)
        {
            velocity += JumpForce;

        }

    }

    //necessary methods for sliding implementation

    //private bool IsGrounded()
    //{
    //    return (Vector3.Angle(Vector3.up, _hitNormal) <= playerController.slopeLimit);
    //}

    //private void SlopeSliding()
    //{
    //    if (!IsGrounded())
    //    {
    //       _velocity.x += (1f - _hitNormal.y) * _hitNormal.x * (1f - _slideFriction);
    //       _velocity.y += (1f - _hitNormal.y) * _hitNormal.z * (1f - _slideFriction);
    //    }
    //}

    private void LimitSpeed()
    {
        if (_speedlimit)
        {
            velocity = new Vector3(Mathf.Clamp(velocity.x, -_maxVelocity.x, _maxVelocity.x), velocity.y, Mathf.Clamp(velocity.z, -_maxVelocity.z, _maxVelocity.z));
        }
    }


    private void GroundMovement()
    {
        //input: here we look at the acis for input and put them into a vector3 to use for the 3 dimensional movement
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            //camera adjustments: we rotate the direction to change with the camera angle
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;

            //smoothing: rotation is smoothed out here, then applied
            float angle = Mathf.SmoothDampAngle(_CSM.transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            _CSM.transform.rotation = Quaternion.Euler(0f, angle, 0f);

            //here we make the movedirection go towards the targetangle: big note, the movement just moves towards the target, and is not smoothed like the character's own rotation
            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
           
            velocity += moveDirection.normalized * speed * Time.fixedDeltaTime;



        }
        playerController.Move(velocity * Time.fixedDeltaTime);
    }

    private void MovementStabilize()
    {
        if (Mathf.Abs( velocity.x) > _minimumSpeed && Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
        {
            velocity.x = 0;
            
        }
        if(Mathf.Abs(velocity.z) > _minimumSpeed && Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
        {
            velocity.z = 0;
        }
    }

    #endregion


    public override void Exit()
    {
        velocity = new Vector3(0, 0, 0);
        base.Exit();
    }

    

}
