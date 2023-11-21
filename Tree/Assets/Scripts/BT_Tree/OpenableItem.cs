using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class OpenableItem : MonoBehaviour
{
    private NavMeshObstacle _obstacle;
    private MeshRenderer _meshRenderer;
    private Collider _collider;

    [SerializeField] private bool _isLocked;

    private void Start()
    {
        _obstacle = GetComponent<NavMeshObstacle>();
        _meshRenderer = GetComponent<MeshRenderer>();
        _collider = GetComponent<Collider>();
    }

    public bool Open()
    {
        if (_isLocked)
            return false;
        else
        {
            _obstacle.enabled = false;
            _meshRenderer.enabled = false;
            _collider.enabled = false;

            return true;
        }
    }
    
}
