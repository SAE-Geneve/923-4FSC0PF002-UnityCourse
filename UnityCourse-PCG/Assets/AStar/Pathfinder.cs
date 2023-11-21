using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Tilemaps;
using AStarNode = AStar.AStarNode;

public class Pathfinder : MonoBehaviour
{

    [SerializeField] private Transform _startPoint;
    [SerializeField] private Transform _endPoint;
    [SerializeField] private Tilemap _groundMap;
    [SerializeField] private Tilemap _pathMap;
    [SerializeField] private TileBase _pathTile;

    private readonly List<Vector3> _neighbours = new List<Vector3>()
    {
        new Vector3(0, 1, 0),
        new Vector3(1, 1, 0),
        new Vector3(1, 0, 0),
        new Vector3(1, -1, 0),
        new Vector3(0, -1, 0),
        new Vector3(-1, -1, 0),
        new Vector3(-1, 0, 0),
        new Vector3(-1, 1, 0),
    };


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        List<Vector3> path = FindAStarPath(_groundMap.WorldToCell(_startPoint.position), _groundMap.WorldToCell(_endPoint.position));
        //_pathMap.ClearAllTiles();
        
        if (path.Count > 0)
        {
            foreach (Vector3 vector3 in path)
            {
                _pathMap.SetTile(_pathMap.WorldToCell(vector3), _pathTile);
            }
        }
        
    }

    private bool IsWalkable(Vector3 position)
    {
        Vector3Int cellPosition = _groundMap.WorldToCell(position);
        return _groundMap.HasTile(cellPosition);
    }

    private Vector3Int ConvertTo(Vector3 v3)
    {
        return new Vector3Int(Mathf.RoundToInt(v3.x), Mathf.RoundToInt(v3.y), Mathf.RoundToInt(v3.z));
    }

    private List<Vector3> FindAStarPath(Vector3 startPosition, Vector3 endPosition)
    {

        List<AStar.AStarNode> aStarList = new List<AStar.AStarNode>();
        List<AStar.AStarNode> visitedNodes = new List<AStar.AStarNode>();
        
        aStarList.Add(new AStar.AStarNode(null, startPosition, 0, Vector3.Distance(startPosition, endPosition)));
        
        while (aStarList.Count > 0)
        {

            AStar.AStarNode currentNode = aStarList.OrderBy(n => n.OptimisedValue).First();
            aStarList.Remove(currentNode);
            
            if (currentNode.Position == endPosition)
                return GetChainedPath(currentNode);

            foreach (var neighbour in _neighbours)
            {

                var neighbourPos = currentNode.Position + neighbour;
                if (IsWalkable(neighbourPos) && !visitedNodes.Exists(n => n.Position == neighbourPos))
                {
                    float cost = Vector3.Distance(currentNode.Position, neighbourPos) + currentNode.Cost;
                    float heuristicScore = Vector3.Distance(endPosition, neighbourPos);

                    var newNode = new AStar.AStarNode(currentNode, neighbourPos, cost, heuristicScore);
                    
                    visitedNodes.Add(newNode);
                    aStarList.Add(newNode);
                    
                }

            }
            
        }
        
        return new List<Vector3>();

    }

    private List<Vector3> GetChainedPath(AStar.AStarNode finalNode)
    {
        Debug.Log("Found a way out !!!!!!");

        List<Vector3> chainedPath = new List<Vector3>();
        AStar.AStarNode pathPoint = finalNode;
        
        while (pathPoint != null)
        {
            chainedPath.Add(pathPoint.Position);
            pathPoint = pathPoint.Parent;

        }
        
        return chainedPath;
        
    }


}
