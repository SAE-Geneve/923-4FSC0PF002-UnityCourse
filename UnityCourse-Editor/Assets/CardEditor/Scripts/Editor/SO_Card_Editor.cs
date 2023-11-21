using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

[CustomEditor(typeof(SO_Card))]
public class SO_Card_Editor : Editor
{
    
    [SerializeField] private VisualTreeAsset _cardMenu;

    private bool _editMode = false;
    private VisualElement _root;
    
    public override VisualElement CreateInspectorGUI()
    {
        Debug.Log("Inspector UI Toolkit !!! " + serializedObject.targetObject.name);
        
        _root = new VisualElement();
        _cardMenu.CloneTree(_root);
        
        _root.Q<Button>("Edit").clicked += ToggleEditMode;
        
        EnableFields();
        //InspectorElement.FillDefaultInspector(root, serializedObject,this);
        return _root;
        
    }

    private void ToggleEditMode()
    {
        _editMode = !_editMode;
        EnableFields();
    }

    private void EnableFields()
    {
        VisualElement fields = _root.Q<VisualElement>("Fields");
        fields.SetEnabled(_editMode);
    }

    // public override void OnInspectorGUI()
    // {
    //     Debug.Log("Inspector Card UI !!! ");
    //     base.OnInspectorGUI();
    // }

}
