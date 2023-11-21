using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StealableItem : MonoBehaviour
{

    private Renderer _frameRenderer;
    [SerializeField] private int _value;
    public int Value => _value;

    // Start is called before the first frame update
    void Start()
    {
        _frameRenderer = GetComponent<Renderer>();
    }

    public void Steal()
    {
        _frameRenderer.enabled = false;
    }
    
}
