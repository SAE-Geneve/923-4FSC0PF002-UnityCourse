using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

[CustomEditor(typeof(MakeRecipe))]
public class RecipeEditor : Editor
{
    public override VisualElement CreateInspectorGUI()
    {
        Debug.Log("UI TOOLKIT Editor ?");

        VisualElement root = new VisualElement();
        InspectorElement.FillDefaultInspector(root, serializedObject, this);
        
        return root;
    }

    // public override void OnInspectorGUI()
    // {
    //     Debug.Log("IMGUI Editor ?");
    //     base.OnInspectorGUI();
    // }
    //
}
