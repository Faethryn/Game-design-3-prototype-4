using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class IdleState : BaseState
{
    [SerializeField]
    private CharacterStateMachine _CSM;
    public CharacterController playerController;
    public IdleState(CharacterStateMachine stateMachine) : base("Idle", stateMachine)
    {
        _CSM = stateMachine;
    
    }



    public override void UpdateLogic()
    {
        base.UpdateLogic();
        InputCheck();
        
    }

    private void InputCheck()
    {
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0 || !playerController.isGrounded)
        {
            _CSM.ChangeState(_CSM.MovingState);
        }
    }
    public override void Exit()
    {
       
    }
}
