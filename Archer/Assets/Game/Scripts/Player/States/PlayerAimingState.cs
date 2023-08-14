using Scripts.Player;
using Scripts.Player.States;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAimingState : PlayerBaseState
{

    private readonly int _aimingHash = Animator.StringToHash("IsAiming");
    private readonly int _aimingMoveSpeedXHash = Animator.StringToHash("AimMoveSpeedX");
    private readonly int _aimingMoveSpeedYHash = Animator.StringToHash("AimMoveSpeedY");

    private bool _isAiming = false;

    public PlayerAimingState(PlayerStateMachine playerStateMachine, bool isAiming) : base(playerStateMachine)
    {
        _isAiming = isAiming;
    }

    public override void Enter()
    {

    }

    public override void Exit()
    {

    }

    public override void Update()
    {
        playerStateMachine.Animator.SetBool(_aimingHash, _isAiming);
        playerStateMachine.Animator.SetFloat(_aimingMoveSpeedXHash, playerStateMachine.InputDirection.x);
        playerStateMachine.Animator.SetFloat(_aimingMoveSpeedYHash, playerStateMachine.InputDirection.y);

        playerStateMachine.CameraController.SetAimingCameraFocus(_isAiming);

        if (!_isAiming)
        {
            playerStateMachine.SwitchState(new PlayerMoveState(playerStateMachine));
        }
    }
}
