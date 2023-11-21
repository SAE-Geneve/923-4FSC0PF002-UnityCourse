using System;
using Unity.VisualScripting;

namespace BT_Tree
{
    public class BT_LoopSequence : BT_Sequence
    {

        private Func<bool> _restartCondition;

        public BT_LoopSequence(string name, Func<bool> condition) : base(name)
        {
            _restartCondition = condition;
        }

        public override BT_Status Process()
        {
            BT_Status status = base.Process();

            if (status == BT_Status.SUCCESS && _restartCondition() == true)
            {
                _idxCurrentChild = 0;
                return BT_Status.RUNNING;
            }
            else
            {
                return status;
            }
            
        }

    }
}
