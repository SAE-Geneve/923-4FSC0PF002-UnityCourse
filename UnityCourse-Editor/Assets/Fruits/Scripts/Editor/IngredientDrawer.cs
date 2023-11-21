using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

[CustomPropertyDrawer(typeof(Ingredient))]
public class IngredientDrawer : PropertyDrawer
{

    public override VisualElement CreatePropertyGUI(SerializedProperty property)
    {

        Ingredient theIngredient = property.objectReferenceValue as Ingredient;
        Debug.Log("Property draw [UI TOOLKI] : " + (theIngredient != null ? theIngredient.Name : "Null ingredient"));

        VisualElement root = new VisualElement();
        root.Add(new PropertyField(property));

        EnumField typeEf = new EnumField("Type", Ingredient.IngredientType.Vegetable);
        root.Add(typeEf);
        
        PropertyField namePf = new PropertyField(property.FindPropertyRelative("_name"));
        root.Add(namePf);

        TextField tf = new TextField("Name");
        tf.value = "kdmldflk";
        
        return root;

    }
    //
    // public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    // {
    //     Ingredient theIngredient = property.serializedObject.targetObject as Ingredient;
    //     Debug.Log("Property draw [IMGUI] : " + (theIngredient != null ? theIngredient.Name : "Null ingredient"));
    //     
    //     base.OnGUI(position, property, label);
    // }

}
