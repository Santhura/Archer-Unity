using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Scripts.Player.Input
{
    [CreateAssetMenu(fileName = "InputReader", menuName = "Game/Input Reader")]
    public class InputReader : ScriptableObject, InputController.IGameplayActions
    {
        public event UnityAction<Vector2> MoveDirectionEvent = delegate { };
        public event UnityAction<Vector2> Look = delegate { };

        public Action OnJumpPerformed;

        private InputController inputControls;

        private void OnEnable()
        {
            if (inputControls == null)
            {
                inputControls = new();
                inputControls.Gameplay.SetCallbacks(this);
            }
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
            Look.Invoke(context.ReadValue<Vector2>());
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            MoveDirectionEvent.Invoke(context.ReadValue<Vector2>());
        }
    }
}