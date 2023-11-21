using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BT_Tree
{
    public class BT_Sequence : BT_Node
    {
        
        protected int _idxCurrentChild = 0;
        
        public BT_Sequence(string name) : base("SEQUENCE " + name)
        {
        }

        public override BT_Status Process()
        {
            
            if (_idxCurrentChild < _childs.Count)
            {
                BT_Status status = _childs[_idxCurrentChild].Process();
                
                if (status == BT_Status.FAILURE)
                    return BT_Status.FAILURE;
                else if(status == BT_Status.RUNNING)
                    return BT_Status.RUNNING;
                else
                    _idxCurrentChild++;
                
                return BT_Status.RUNNING;
                
            }

            return BT_Status.SUCCESS;
            
        }
    }
}
