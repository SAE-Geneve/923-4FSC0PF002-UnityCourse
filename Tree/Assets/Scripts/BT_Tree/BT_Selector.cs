﻿namespace BT_Tree
{
    public class BT_Selector : BT_Node
    {
        private int idxSelectedChild = 0;

        public BT_Selector(string name) : base("SELECTOR " + name)
        {
        }

        public override BT_Status Process()
        {

            BT_Status status = _childs[idxSelectedChild].Process();

            switch (status)
            {
                case BT_Status.RUNNING:
                case BT_Status.SUCCESS:
                    return status;
                    break;

                case BT_Status.FAILURE:
                    idxSelectedChild++;
                    if (idxSelectedChild >= _childs.Count)
                    {
                        idxSelectedChild = 0;
                        return BT_Status.FAILURE;
                    }
                    else
                    {
                        return BT_Status.RUNNING;
                    }
                default:
                    return BT_Status.FAILURE;
            }

        }
    }
}
