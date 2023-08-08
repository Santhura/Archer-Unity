using Scripts.Player.States;
using Scripts.StateMachineAbstracts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Player
{
    [RequireComponent(typeof(InputReader))]
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(CharacterController))]
    public class PlayerStateMachine : StateMachine
    {
        private CharacterController _characterController;
        private Animator _animator;
        private InputReader _inputReader;

        public InputReader InputReader { get { return _inputReader; } }
        public CharacterController CharacterController { get { return _characterController; } }
        public Animator Animator { get { return _animator; } }

        public Vector3 velocity;
        public float MovementSpeed { get; private set; } = 5f;
        public float JumpForce { get; private set; } = 5f;
        public float LookRotationDampFactor { get; private set; } = 10f;
        public Transform mainCameraTransform { get ; private set; }


        private void Awake()
        {
            mainCameraTransform = Camera.main.transform;
            _characterController = GetComponent<CharacterController>();
            _animator = GetComponent<Animator>();
            _inputReader = GetComponent<InputReader>();
        }

        private void Start()
        {
            SwitchState(new PlayerMoveState(this));
        }

    }
}
