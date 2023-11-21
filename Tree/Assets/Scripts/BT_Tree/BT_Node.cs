using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BT_Tree
{
    public enum BT_Status{
        RUNNING,
        FAILURE,
        SUCCESS
    }
    
    public abstract class BT_Node
    {
        protected string _name;
        protected int _depth;
        public int Depth
        {
            get { return _depth; }
            set { _depth = value; }
        }

        protected List<BT_Node> _childs = new List<BT_Node>();

        public BT_Node(string name)
        {
            _name = name;
            _depth = 0;
        }
        
        public virtual BT_Status Process()
        {
            Debug.Log("I'm the node " + _name + " Depth:" + _depth);
            foreach (BT_Node child in _childs)
            {
                
                BT_Status status =  child.Process();
                Debug.Log("I'm the node " + child._name + " Depth:" + child._depth + " STATUS=" + status);
               
            }

            return BT_Status.SUCCESS;

        }

        public void AddNode(BT_Node newNode)
        {
            newNode.Depth = this.Depth + 1; 
            _childs.Add(newNode);
        }
        
    }
}
