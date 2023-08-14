using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.StateMachineAbstracts
{
    public abstract class StateMachine : MonoBehaviour
    {
        private State _currentState;
        public void SwitchState(State state)
        {
            _currentState?.Exit();
            _currentState = state;
            _currentState.Enter();
        }

        protected virtual void Update()
        {
            _currentState?.Update();
        }
    }
}
