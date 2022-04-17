using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStateMachine : BaseStateMachine
{
    public IdleState IdleState;

    public GroundMovementState MovingState;

    public SprintingState SprintState;

    public Flyingstate FlyState;

    public ClimbingState ClimbingState;

    public MidAirState MidAirState;


    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
       
    }


    protected override BaseState GetInitialState()
    {
        return MovingState;
    }
    //void OnControllerColliderHit(ControllerColliderHit hit)
    //{
    //    movingState._hitNormal = hit.normal;
    //}

}
