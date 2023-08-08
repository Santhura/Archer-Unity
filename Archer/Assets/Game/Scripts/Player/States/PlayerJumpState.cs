using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Scripts.Player.States
{
    public class PlayerJumpState : PlayerBaseState
    {
        private readonly int _jumpHas = Animator.StringToHash("");
        private const float CROSS_FADE_DURATION = 0.1f;
        public PlayerJumpState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
        {
        }

        public override void Enter()
        {
            playerStateMachine.currentState = "Jumping";
            playerStateMachine.velocity = new(playerStateMachine.velocity.x, playerStateMachine.JumpForce, playerStateMachine.velocity.z);
            playerStateMachine.Animator.CrossFadeInFixedTime(_jumpHas, CROSS_FADE_DURATION);
        }

        public override void Exit()
        {
            
        }

        public override void Update()
        {
            ApplyGravity();
            if (playerStateMachine.velocity.y <= 0f)
                playerStateMachine.SwitchState(new PlayerFallState(playerStateMachine));

            FaceMoveDirection();
            Move();
        }
    }
}
