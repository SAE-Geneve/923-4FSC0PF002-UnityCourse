using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

namespace FSM_Starter
{
    
    public class FSM_PatrolState : FSM_IState
    {

        private FSM_Tank _tank;

        public FSM_PatrolState(FSM_Tank tank)
        {
            _tank = tank;
        }
        
        public void OnEnter()
        {
            Debug.Log("Enter Patrol :) ");
            _tank.Animator.enabled = true;
            _tank.NavmeshAgent.SetDestination(_tank.WaypointsManager.GetCurrentDestination());
            _tank.StartTargetting();
        }

        public void OnExit()
        {
            Debug.Log("Exit Patrol :( ");
            _tank.Animator.enabled = false;
            _tank.StopTargetting();
        }

        public void Tick()
        {
            Debug.Log("Tick Patrol !!! ");

            float distance = Vector3.Distance(_tank.transform.position, _tank.WaypointsManager.GetCurrentDestination());
            if (distance < 0.5f)
            {
                _tank.NavmeshAgent.SetDestination(_tank.WaypointsManager.GetNextPatrolDestination());
            }
        }
    }

}
