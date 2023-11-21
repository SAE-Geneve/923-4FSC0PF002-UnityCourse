using System;
using System.Collections.Generic;
using BehaviourTrees;

namespace FSM_Starter
{
    public class FSM_StateMachine
    {
        private FSM_IState _currentState;
        
        private readonly Dictionary<Type,  List<FSM_Transition>> _allTransitions = new Dictionary<Type, List<FSM_Transition>>();
        private readonly List<FSM_Transition> _emptyTransitions = new List<FSM_Transition>(0);
        
        public void Tick()
        {
            List<FSM_Transition> _currentTypeTransitions = new List<FSM_Transition>();
            // Check Transitions
            if (_allTransitions.TryGetValue(_currentState.GetType(), out _currentTypeTransitions))
            {
                foreach (FSM_Transition transition in _currentTypeTransitions)
                {
                    if (transition.Condition() == true)
                    {
                        SetState(transition.To);
                    }
                }
            }
            
            // Tick the current state
            if(_currentState != null)
                _currentState.Tick();
            
        }

        public void AddTransition(FSM_IState from, FSM_IState to, Func<bool> condition)
        {
            if (_allTransitions.TryGetValue(from.GetType(), out List<FSM_Transition> existingConditions))
            {
                // deja des transitions
                existingConditions.Add(new FSM_Transition(to, condition));
            }
            else
            {
                // pas deja des transitions
                List<FSM_Transition> newConditions = new List<FSM_Transition>();
                newConditions.Add(new FSM_Transition(to, condition));
                _allTransitions.Add(from.GetType(), newConditions);
            }
            
        }
        
        public void SetState(FSM_IState newState)
        {
            if(_currentState != null)
                _currentState.OnExit();
            
            _currentState = newState;
            _currentState.OnEnter();
            
        }
        
    }
}
