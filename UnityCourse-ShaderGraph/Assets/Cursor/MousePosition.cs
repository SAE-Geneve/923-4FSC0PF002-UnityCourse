using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePosition : MonoBehaviour
{

    [SerializeField] private Transform _debugTransform;
    
    private Material _material;
    private Camera _main;
    
    // Start is called before the first frame update
    void Start()
    {
        _material = GetComponent<MeshRenderer>().material;
        _main = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        var mouseWorldPoint = _main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 25));
        _material.SetVector("_Mouse", (Vector4)(mouseWorldPoint));
        _debugTransform.position = mouseWorldPoint;

        // Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
        // if (Physics.Raycast(r, out var hitInfo))
        // {
        //     if (hitInfo.collider.gameObject == this.gameObject)
        //     {
        //         var _mousePosition = hitInfo.point;
        //         // if(_debugObj != null)
        //         //     _debugObj.position = _mousePosition;
        //         
        //         _material.SetVector("_MouseXY", (Vector4)(_mousePosition));
        //     }
        // }

    }
}
