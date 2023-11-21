using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM_Starter
{
    public interface FSM_IState
    {

        public void OnEnter();
        public void OnExit();
        public void Tick();
        
    }
}
