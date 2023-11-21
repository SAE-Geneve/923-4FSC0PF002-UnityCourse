using System.Collections.Generic;
using UnityEngine;

namespace AStar
{

    public class AStarNode
    {

        private AStarNode _parent;

        private float _cost;
        private float _heuristicScore;
        private Vector3 _position;

        public AStarNode(AStarNode parent, Vector3 position, float cost, float heuristicScore)
        {
            _parent = parent; 
            
            _position = position;
            _cost = cost;
            _heuristicScore = heuristicScore;
            
        }

        public Vector3 Position => _position;
        public float Cost => _cost;

        public float OptimisedValue => _cost + _heuristicScore;
        public AStarNode Parent => _parent;

    }
    
}
