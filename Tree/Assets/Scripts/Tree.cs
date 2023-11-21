using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Tree : MonoBehaviour
{
    private Node _root = new Node();

    [SerializeField] private int _depthMax = 5;
    
    private void Start()
    {
        
        // Determiner le dénombrement du nombre de noeuds en f° de la depth
        _root.State = Node.GameState.Start;

        List<Node> tempNodes = FillTree();
        _root = FilterTree(tempNodes);

        Debug.Log("end of tree");

    }

    private Node FilterTree(List<Node> tempNodes)
    {
        
        for (int depth = 0; depth < _depthMax; depth++)
        {
            List<Node> nextNodes = new List<Node>();

            if (depth == 0)
            {
                // Link all next nodes -------------------------------------------------------
            }else if (depth == _depthMax)
            {
                // Link all previous nodes ---------------------------------------------------
            }
            else
            {
                nextNodes.Add(new Node(depth));
            }
        }

        return new Node();

    }

    private List<Node> FillTree()
    {

        List<Node> tempNodes = new List<Node>();
        
        for (int depth = 0; depth < _depthMax; depth++)
        {
            if (depth != 0 || depth != (_depthMax - 1))
            {
                // ---------------------------------------
                // Tirage nb de noeud par depth
                int totalNodes = Random.Range(1, 4);
                for (int nbNode = 0; nbNode < totalNodes; nbNode++)
                {
                    tempNodes.Add(new Node(depth));
                }
            }
            else
            {
                tempNodes.Add(new Node(depth));
            }
        }

        return tempNodes;
        
    }

    private void Update()
    {
        _root.Process();
    }

}
