using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ClimbingState : BaseState
{
    [SerializeField]
    private CharacterStateMachine _CSM;
    public ClimbingState(CharacterStateMachine stateMachine) : base("Moving", stateMachine)
    {
        _CSM = stateMachine;
    }
    [SerializeField] private float speed = 30f;
    
    
    public Vector3 JumpForce;

    public CharacterController playerController;
    public Transform cam;

    //[SerializeField] private float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    //private bool _appliedGravity = false;

    public Vector3 velocity;
    [SerializeField] private Vector3 _maxVelocity;
    [SerializeField] private bool _speedlimit;

    [SerializeField] private float _dragOnGround;
    [SerializeField] private float _minimumSpeed;

    private bool _raycastHit = true;
    
    private RaycastHit _hitInfo;

    private RaycastHit _previousHeadHitInfo;
    private bool _previousHeadRaycastHit = true;

    private RaycastHit _currentHeadHitInfo;
    private bool _currentHeadRaycastHit = true;

    public override void Enter()
    {
        base.Enter();
    }
    public override void UpdateLogic()
    {
        base.UpdateLogic();

        TransitionChecks();
    }

    private void TransitionChecks()
    {
        MidAirTransition();
        GroundTransition();
    }

    private void GroundTransition()
    {
        if (playerController.isGrounded)
            _CSM.ChangeState(_CSM.MovingState);
    }

    private void MidAirTransition()
    {
        JumpTransition();
        LeaveWallTransition();
        ClimbTransition();

        _previousHeadHitInfo = _currentHeadHitInfo;
        _previousHeadRaycastHit = _currentHeadRaycastHit;
    }

    private void ClimbTransition()
    {
        if (!_currentHeadRaycastHit && _previousHeadRaycastHit != _currentHeadRaycastHit)
        {
            playerController.Move(_previousHeadHitInfo.point - _CSM.transform.position + (Vector3.up + _CSM.transform.forward) * _CSM.transform.parent.localScale.x);
            _CSM.ChangeState(_CSM.MidAirState);
        }
    }

    private void LeaveWallTransition()
    {
        if (!_raycastHit)
        {
            _CSM.MidAirState.velocity = velocity;
            _CSM.ChangeState(_CSM.MidAirState);
        }
    }

    private void JumpTransition()
    {
        if (Input.GetButton("Jump"))
        {
            ApplyRotationWallJump();
            ApplyWallJump();
            _CSM.MidAirState.velocity = velocity;
            _CSM.ChangeState(_CSM.MidAirState);
        }
    }

    private void ApplyRotationWallJump()
    {
        if (_raycastHit)
        {
            float angle = Mathf.Atan2(_hitInfo.normal.x, _hitInfo.normal.z) * Mathf.Rad2Deg;
            _CSM.transform.rotation = Quaternion.Euler(0f, angle, 0f);
        }
    }

    private void ApplyWallJump()
    {
        velocity += JumpForce;
        velocity += _CSM.transform.forward * 5f;
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
        UpdateRaycasts();

        ClimbingMovement();

        Rotation();

        playerController.Move(velocity * Time.fixedDeltaTime);
    }

    private void UpdateRaycasts()
    {
        _raycastHit = RaycastUpdate();
        _currentHeadRaycastHit = HeadRaycastUpdate();
    }

    private bool HeadRaycastUpdate()
    {
        //Debug.DrawLine(_CSM.transform.position + Vector3.up *.8f, _CSM.transform.position + Vector3.up * .8f + _CSM.transform.forward, Color.red, 10f);
        return Physics.Raycast(_CSM.transform.position + (Vector3.up * .8f * _CSM.transform.parent.localScale.x), _CSM.transform.forward, out _currentHeadHitInfo, 1f * _CSM.transform.parent.localScale.x);
    }

    private bool RaycastUpdate()
    {
        Debug.DrawLine(_CSM.transform.position, _CSM.transform.position + _CSM.transform.forward * _CSM.transform.parent.localScale.x, Color.red, 10f);
        return Physics.Raycast(_CSM.transform.position, _CSM.transform.forward * _CSM.transform.parent.localScale.x, out _hitInfo, 1f);
    }

    private void Rotation()
    {
        if (_raycastHit)
        {
            playerController.Move(_hitInfo.point - _CSM.transform.position);
            float angle = Mathf.Atan2(-_hitInfo.normal.x, -_hitInfo.normal.z) * Mathf.Rad2Deg;
            _CSM.transform.rotation = Quaternion.Euler(0f, angle, 0f);
        }
    }

    private void ClimbingMovement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, vertical, 0f).normalized;
        if (direction.magnitude >= 0.1f)
        {
            Vector3 moveDirection = direction.x * playerController.transform.right + direction.y * playerController.transform.up;
            velocity += moveDirection * speed * Time.fixedDeltaTime;
        }
        else
        {
            velocity = Vector3.zero;
        }
    }

    public override void Exit()
    {
        velocity = new Vector3(0, 0, 0);
        base.Exit();
    }
}
