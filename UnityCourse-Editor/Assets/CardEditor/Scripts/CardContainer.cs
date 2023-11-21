using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

//[ExecuteInEditMode]
public class CardContainer : MonoBehaviour
{
    [Header("Datas")]
    [SerializeField] private SO_Card _soCardModel;

    [Header("Fields")]
    [SerializeField] private SpriteRenderer _background;
    // [SerializeField] private SpriteRenderer _portrait;
    [SerializeField] private TMP_Text _attackText;
    [SerializeField] private TMP_Text _defenseText;
    [SerializeField] private TMP_Text _name;
    [SerializeField] private TMP_Text _desc;
    [SerializeField] private TMP_Text _manaCost;

    public SO_Card SoCardModel { get; set; }

    private void OnValidate()
    {
        //LoadCard();
    }

    private void Start()
    {
       
    }

    public void LoadCard()
    {
        
        if(_soCardModel == null)
            return;
        
        _background.sprite = _soCardModel.Sprite;
        // _portrait;
        _attackText.text = _soCardModel.Attack.ToString();
        _attackText.color = _soCardModel.TextColor;
        //_attackText.GetComponent<MeshRenderer>().material.color = cardModel.TextColor;
        
        _defenseText.text = _soCardModel.Defense.ToString();
        _defenseText.color = _soCardModel.TextColor;
        
        _name.text = _soCardModel.Name.ToString();
        _name.color = _soCardModel.TextColor;
        
        _desc.text = _soCardModel.Description.ToString();
        _desc.color = _soCardModel.TextColor;
        
        _manaCost.text = _soCardModel.ManaCost.ToString();
        _manaCost.color = _soCardModel.TextColor;

    }

    public void NewCard()
    {
        Debug.Log("New");
    }

    public void SaveCard()
    {
        Debug.Log("Save Card");
    }

    public void SaveCardAs()
    {
        Debug.Log("Save Card As");
    }
}
