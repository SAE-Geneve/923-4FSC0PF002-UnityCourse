using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName = "CardCreator/Card", fileName = "newCard")]
public class SO_Card : ScriptableObject
{
    
    [SerializeField] private Sprite _sprite;
    [SerializeField] private int _manaCost;
    [SerializeField] private int _attack;
    [SerializeField] private int _defense;
    [SerializeField] private string _name;
    [SerializeField][Multiline] private string _description;
    [SerializeField] private Color _textColor;

    public Sprite Sprite => _sprite;
    public int ManaCost => _manaCost;
    public int Attack => _attack;
    public int Defense => _defense;
    public string Name => _name;
    public string Description => _description;
    public Color TextColor => _textColor;

}
