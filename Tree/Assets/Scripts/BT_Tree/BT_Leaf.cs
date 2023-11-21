using System;
using UnityEngine;

namespace BT_Tree
{
    public class BT_Leaf : BT_Node
    {

        private Func<BT_Status> _performAction;

        public BT_Leaf(string name, Func<BT_Status> performAction) : base(name)
        {
            _performAction = performAction;
        }

        public override BT_Status Process()
        {
            BT_Status status = _performAction();
            Debug.Log("I'm the node " + _name + " Depth:" + _depth + " STATUS=" + status);
            return status;
        }
        
    }
}
