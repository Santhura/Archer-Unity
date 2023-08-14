using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Player.States
{
    public class PlayerMoveState : PlayerBaseState
    {
        private readonly int _moveSpeedHash = Animator.StringToHash("MoveSpeed");
        private readonly int _moveBlendTreeHash = Animator.StringToHash("MoveBlendTree");
        private const float ANIMATION_DAMP_TIME = 0.1f;
        private const float CROSS_FADE_DURATION = 0.1f;

        public PlayerMoveState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
        {
        }

        public override void Enter()
        {
            playerStateMachine.currentState = "moving";
            playerStateMachine.velocity.y = Physics.gravity.y;
            playerStateMachine.Animator.CrossFadeInFixedTime(_moveBlendTreeHash, CROSS_FADE_DURATION);
            playerStateMachine.InputReader.OnJumpPerformed += SwitchToJumpState;
        }

        public override void Exit()
        {
            playerStateMachine.InputReader.OnJumpPerformed -= SwitchToJumpState;
        }

        public override void Update()
        {
            //if (!playerStateMachine.CharacterController.isGrounded)
            //{
            //    playerStateMachine.SwitchState(new PlayerFallState(playerStateMachine));
            //}
            CalculateMoveDirection();
            FaceMoveDirection();
            Move();
            playerStateMachine.Animator.SetFloat(_moveSpeedHash, playerStateMachine.InputDirection.sqrMagnitude > 0f ? 1f : 0f, ANIMATION_DAMP_TIME, Time.deltaTime);
        }

        private void SwitchToJumpState()
        {
            playerStateMachine.SwitchState(new PlayerJumpState(playerStateMachine));
        }
    }
}
