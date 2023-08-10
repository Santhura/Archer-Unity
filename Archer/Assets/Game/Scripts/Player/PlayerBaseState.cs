using Scripts.Player;
using Scripts.StateMachineAbstracts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Player
{
    public abstract class PlayerBaseState : State
    {
        protected readonly PlayerStateMachine playerStateMachine;
        protected PlayerBaseState(PlayerStateMachine playerStateMachine) 
        {
            this.playerStateMachine = playerStateMachine;
        }

        protected void CalculateMoveDirection()
        {
            Vector3 cameraForward = new(playerStateMachine.mainCameraTransform.forward.x, 0, playerStateMachine.mainCameraTransform.forward.z);
            Vector3 cameraRight = new(playerStateMachine.mainCameraTransform.right.x, 0, playerStateMachine.mainCameraTransform.right.z);

            Vector3 moveDirection = cameraForward.normalized * playerStateMachine.InputDirection.y + cameraRight.normalized * playerStateMachine.InputDirection.x;
            playerStateMachine.velocity.x = moveDirection.x * playerStateMachine.MovementSpeed;
            playerStateMachine.velocity.z = moveDirection.z * playerStateMachine.MovementSpeed;
        }

        protected void FaceMoveDirection()
        {
            Vector3 faceDirection = new(playerStateMachine.velocity.x, 0f, playerStateMachine.velocity.z);
            if (faceDirection == Vector3.zero) return;

            playerStateMachine.transform.rotation = Quaternion.Slerp(playerStateMachine.transform.rotation, Quaternion.LookRotation(faceDirection), playerStateMachine.LookRotationDampFactor * Time.deltaTime);
        }

        protected void ApplyGravity()
        {
            if(playerStateMachine.velocity.y > Physics.gravity.y)
            {
                playerStateMachine.velocity.y += Physics.gravity.y * Time.deltaTime;
            }
        }

        protected void Move()
        {
            playerStateMachine.CharacterController.Move(playerStateMachine.velocity * Time.deltaTime);
        }
    }
}
