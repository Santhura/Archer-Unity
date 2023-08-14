using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Scripts.Player.States
{
    public class PlayerFallState : PlayerBaseState
    {
        private readonly int _fallHash = Animator.StringToHash("Fall");
        public const float CROSS_FADE_DURATION = 0.1f;
        public PlayerFallState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
        {
        }

        public override void Enter()
        {
            playerStateMachine.velocity.y = 0f;
            playerStateMachine.Animator.CrossFadeInFixedTime(_fallHash, CROSS_FADE_DURATION);
        }

        public override void Exit()
        {
            
        }

        public override void Update()
        {
            ApplyGravity();
            if (playerStateMachine.CharacterController.isGrounded)
                playerStateMachine.SwitchState(new PlayerMoveState(playerStateMachine));
        }
    }
}
