using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPicker : MonoBehaviour
{

    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private Color _color;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _renderer.color = _color;
    }
}
