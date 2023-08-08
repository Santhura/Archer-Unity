using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.StateMachineAbstracts
{
    public abstract class State
    {
        public abstract void Enter();
        public abstract void Update();
        public abstract void Exit();
    }
}