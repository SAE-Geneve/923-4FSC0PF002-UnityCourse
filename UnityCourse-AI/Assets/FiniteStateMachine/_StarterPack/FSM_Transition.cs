using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM_Starter
{
    public class FSM_Transition
    {
        public FSM_IState To { get; }
        public Func<bool> Condition { get; }

        public FSM_Transition(FSM_IState to, Func<bool> condition)
        {
            To = to;
            Condition = condition;
        }
    }
}
