using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

//[CustomPropertyDrawer(typeof(SO_Card), true)]
public class SO_Card_PropertyDrawer : PropertyDrawer
{

    public override VisualElement CreatePropertyGUI(SerializedProperty property)
    {
        var root = new VisualElement();
        Debug.Log("SO Card Property GUI");

        // Fields ---------------------------------------------------------
        Label title = new Label("Card model");
        
        PropertyField card = new PropertyField(property);
        PropertyField sprite = new PropertyField(property.FindPropertyRelative("Sprite"));
        PropertyField manaCost = new PropertyField(property.serializedObject.FindProperty("ManaCost"));
        PropertyField attack = new PropertyField(property.serializedObject.FindProperty("Attack"));
        PropertyField defense = new PropertyField(property.serializedObject.FindProperty("Defense"));
        PropertyField name = new PropertyField(property.serializedObject.FindProperty("Name"));
        PropertyField description = new PropertyField(property.serializedObject.FindProperty("Description"));
        PropertyField textColor = new PropertyField(property.serializedObject.FindProperty("TextColor"));
        
        root.Add(title);
        
        root.Add(card);
        root.Add(sprite);
        root.Add(manaCost);
        root.Add(attack);
        root.Add(defense);
        root.Add(name);
        root.Add(description);
        root.Add(textColor);

        return root;    

    }

}
