using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Node
{
    
    public enum GameState
    {
        Start,
        Ennemies,
        Shop,
        Treasure,
        Event,
        Boss
    }

    private Sprite icon;

    public GameState State;
    private int _myDepth;
    public List<Node> Childs = new List<Node>();

    public int Neighbourhood = 0;

    public Node()
    {
        _myDepth = 0;
    }
    
    public Node(int myDepth)
    {
        _myDepth = myDepth;
    }
    
    public void AddNode(Node childNode)
    {
        Childs.Add(childNode);
    }

    public void Process()
    {
        Debug.Log("Node Depth=" + _myDepth + " : Type=" + State + " : Neighbourhood=" + Neighbourhood);

        if (Childs.Count > 0)
        {
            foreach (Node child in Childs)
            {
                child.Process();
            }
        }

    }
}
