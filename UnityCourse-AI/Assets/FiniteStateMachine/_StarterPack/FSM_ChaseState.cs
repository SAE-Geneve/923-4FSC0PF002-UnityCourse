using UnityEngine;

namespace FSM_Starter
{
    public class FSM_ChaseState : FSM_IState
    {

        public void OnEnter()
        {
            Debug.Log("Enter Chase state");
        }

        public void OnExit()
        {
            Debug.Log("Exit Chase state");
        }

        public void Tick()
        {
            Debug.Log("Tick Chase state");

        }
    }
}
