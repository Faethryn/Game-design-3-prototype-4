using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class MidAirState : BaseState
{
    [SerializeField]
    private CharacterStateMachine _CSM;
    public MidAirState(CharacterStateMachine stateMachine) : base("Moving", stateMachine)
    {
        _CSM = stateMachine;
    }
    //[SerializeField] private float speed = 30f;

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

    public override void Enter()
    {
        base.Enter();
    }
    public override void UpdateLogic()
    {
        base.UpdateLogic();
        TransitionCheck();
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
        ApplyGravity();

        playerController.Move(velocity * Time.fixedDeltaTime);
    }

    private void ApplyGravity()
    {
        velocity += Physics.gravity * Time.fixedDeltaTime;
    }

    public void TransitionCheck()
    {
        GroundTransition();
        FlyingTransition();
        ClimbingTransition();
    }

    private void GroundTransition()
    {
        if (playerController.isGrounded)
        {
            _CSM.MovingState.velocity = velocity;
            _CSM.ChangeState(_CSM.MovingState);
        }
            
    }

    private void FlyingTransition()
    {
        if (!playerController.isGrounded && Input.GetButtonDown("Jump"))
        {
            _CSM.FlyState.velocity = velocity;
            _CSM.ChangeState(_CSM.FlyState);
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

    public override void Exit()
    {
        velocity = new Vector3(0, 0, 0);
        //_appliedGravity = false;
        base.Exit();
    }
}
