using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Scripts.Player
{
    public class InputReader : MonoBehaviour, InputController.IGameplayActions
    {
        public Vector2 MoveDirection;
        public Vector2 Look;

        public Action OnJumpPerformed;

        private InputController inputControls;

        private void OnEnable()
        {
            if (inputControls == null) return;
            inputControls = new();
            inputControls.Gameplay.SetCallbacks(this);
            inputControls.Gameplay.Enable();
        }

        private void OnDisable()
        {
            if (inputControls == null) return;
            inputControls.Gameplay.Disable();
        }

        public void OnJump(InputAction.CallbackContext context)
        {
            if (!context.performed) return;

            OnJumpPerformed?.Invoke();
        }

        public void OnLook(InputAction.CallbackContext context)
        {
            Look = context.ReadValue<Vector2>();
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            MoveDirection = context.ReadValue<Vector2>();
        }
    }
}