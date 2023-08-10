using Scripts.Player.Input;
using Scripts.Player.States;
using Scripts.StateMachineAbstracts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Player
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(CharacterController))]
    public class PlayerStateMachine : StateMachine
    {
        [SerializeField] private InputReader _inputReader;
        
        // privates
        private CharacterController _characterController;
        private Animator _animator;
        private Vector2 _inputDirection = Vector2.zero;

        // Properties
        public InputReader InputReader { get { return _inputReader; } }
        public CharacterController CharacterController { get { return _characterController; } }
        public Animator Animator { get { return _animator; } }
        public Vector2 InputDirection { get { return _inputDirection; } }


        // public variables
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
        }

        private void Start()
        {
            if (_inputReader == null) {
                Debug.LogError("no input reader scriptable object");
                Application.Quit();
            }
            SwitchState(new PlayerMoveState(this));
        }

        // Events
        public void OnMovement(Vector2 movement)
        {
            _inputDirection = movement;
        }

        private void OnEnable()
        {
            _inputReader.MoveDirectionEvent += OnMovement;
        }
    }
}
