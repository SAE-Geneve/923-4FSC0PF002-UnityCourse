using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BT_Tree;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

public class BehaviourTree_Robber : MonoBehaviour
{

    [SerializeField] private OpenableItem _frontDoor;
    [SerializeField] private OpenableItem _backDoor;
    [SerializeField] private float _doorDistance;
    
    [SerializeField] private Transform _van;
    [SerializeField] private StealableItem _itemToSteal;

    [SerializeField] private List<StealableItem> _stealableItems;
    [SerializeField] private int _amountGoal;

    private NavMeshAgent _agent;
    
    private BT_Node _Behaviour = new BT_Root("Danny Ocean");
    private BT_LoopSequence _StealSequence;
    private BT_Sequence _FrontDoorSequence = new BT_Sequence("Front door");
    private BT_Sequence _BackDoorSequence = new BT_Sequence("Back door");
    
    private BT_Selector _PickDoorSelector = new BT_Selector("Pick a door");
    
    private int _amount;
    private List<StealableItem> _actualStealableItems;
    
    // Start is called before the first frame update
    void Start()
    {

        _actualStealableItems = _stealableItems.ToList();
        
        _agent = GetComponent<NavMeshAgent>();
        
        _StealSequence = new BT_LoopSequence("Steal loop", StealRestartCondition);
        
        _Behaviour.AddNode(_StealSequence);
        
        _StealSequence.AddNode(_PickDoorSelector);
        _StealSequence.AddNode(new BT_Leaf("Steal a frame", StealAnItem));
        _StealSequence.AddNode(new BT_Leaf("Go Back to van", GoBackToVan));
        
        _PickDoorSelector.AddNode(_FrontDoorSequence);
        _PickDoorSelector.AddNode(_BackDoorSequence);
        
        _FrontDoorSequence.AddNode(new BT_Leaf("Go the front door", GoToTheFrontDoor));
        _FrontDoorSequence.AddNode(new BT_Leaf("Open the front door", OpenTheFrontDoor));
        
        _BackDoorSequence.AddNode(new BT_Leaf("Go the back door", GoToTheBackDoor));
        _BackDoorSequence.AddNode(new BT_Leaf("Open the back door", OpenTheBackDoor));
        
    }

    private bool StealRestartCondition()
    {
        if (_actualStealableItems.Count > 0 && _amount < _amountGoal)
            return true;
        else
            return false;
            
    }

    private BT_Status GoBackToVan()
    {
        _amount += _itemToSteal.Value;
        
        return GoToDestination(_van);
    }
    private BT_Status GoToTheFrontDoor()
    {
        return GoToDestination(_frontDoor.transform);
    }
    private BT_Status GoToTheBackDoor()
    {
        return GoToDestination(_backDoor.transform);
    }

    private BT_Status GoToDestination(Transform destination)
    {

        _agent.SetDestination(destination.position);

        // if (_agent.pathPending || _agent.remainingDistance > _agent.stoppingDistance)
        if (Vector3.Distance(transform.position, destination.position) > _doorDistance)
            return BT_Status.RUNNING;
        else
            return BT_Status.SUCCESS;
    }

    private BT_Status StealAnItem()
    {
        // -----------------------------------------------------------
        _itemToSteal = _actualStealableItems.OrderBy(i => i.Value).Last();
        
        Debug.Log("Item to steal " + _itemToSteal.name + " Value=" + _itemToSteal.Value);
        
        _agent.SetDestination(_itemToSteal.transform.position);

        if (_agent.pathPending)
            return BT_Status.RUNNING;
        
        if(_agent.remainingDistance > _agent.stoppingDistance)
        {
            return BT_Status.RUNNING;
        }        
        else
        {
            _itemToSteal.Steal();
            _actualStealableItems.Remove(_itemToSteal);
            return BT_Status.SUCCESS;
        }
    }

    private BT_Status OpenTheFrontDoor()
    {
        return OpenADoor(_frontDoor);
    }
    private BT_Status OpenTheBackDoor()
    {
        return OpenADoor(_backDoor);
    }
    private BT_Status OpenADoor(OpenableItem item)
    {
        if (item.Open())
            return BT_Status.SUCCESS;
        else
            return BT_Status.FAILURE;
    }





    // Update is called once per frame
    void Update()
    {
        _Behaviour.Process();
    }
}
