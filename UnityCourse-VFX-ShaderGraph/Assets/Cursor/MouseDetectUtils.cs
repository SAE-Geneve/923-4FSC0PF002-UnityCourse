using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDetectUtils : MonoBehaviour
{

    [SerializeField] private Vector3 _mousePosition;
    [SerializeField] private Material _shader;
    [SerializeField] private Transform _debugObj;
    
    // Start is called before the first frame update
    void Start()
    {
        _shader = GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {

        Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(r, out var hitInfo)){
            if (hitInfo.collider.gameObject == this.gameObject)
            {
                _mousePosition = hitInfo.point;
                if(_debugObj != null)
                    _debugObj.position = _mousePosition;
                
                _shader.SetVector("_Position", (Vector4)(_mousePosition));
            }
        }
        
    }
    
}
