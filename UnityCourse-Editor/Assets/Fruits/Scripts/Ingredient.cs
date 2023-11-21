using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Ingredient : MonoBehaviour
{

    public enum IngredientType
    {
        Fruit,
        Vegetable,
        Condiment
    }

    [SerializeField] private string _name;
    
    [SerializeField] private IngredientType _type;
    [SerializeField] private int _qty;
    [SerializeField] private float _mass;
    [SerializeField] private int _calories;

    public string Name => _name;

}
