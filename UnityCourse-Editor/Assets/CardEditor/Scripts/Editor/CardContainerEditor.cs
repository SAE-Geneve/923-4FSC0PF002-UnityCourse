using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;

[CustomEditor(typeof(CardContainer))]
public class CardContainerEditor : Editor
{
    
    [SerializeField] private VisualTreeAsset _buttonsMenu;
    private VisualElement _docRoot;
    private CardContainer _cardContainer;

    public override VisualElement CreateInspectorGUI()
    {
        // Create a new VisualElement to be the root of our inspector UI
        _docRoot = new VisualElement();
        // Get datas (serialized object)
        _cardContainer = serializedObject.targetObject.GetComponent<CardContainer>();
        
        // Buttons --------------------------------------------------------------------------------
        _buttonsMenu.CloneTree(_docRoot);
        _docRoot.Q<Button>("NewCard").clicked += _cardContainer.NewCard;
        _docRoot.Q<Button>("LoadCard").clicked += _cardContainer.LoadCard;
        _docRoot.Q<Button>("SaveCard").clicked += _cardContainer.SaveCard;
        _docRoot.Q<Button>("SaveCardAs").clicked += _cardContainer.SaveCardAs;

        // Property field for a card -------------------------------------------------------------
        ObjectField pf = _docRoot.Q<ObjectField>("CardModel");
        pf.objectType = typeof(SO_Card);
        pf.bindingPath = "_soCardModel";
        // pf.
        // pf.RegisterCallback<ChangeEvent<Card>>(OnCardChanged);

        // Default inspector in foldout
        var foldout = new Foldout() {viewDataKey = "fields_foldout", text = "Fields foldout"};
        InspectorElement.FillDefaultInspector(foldout, serializedObject, this);
        _docRoot.Add(foldout);
        
        _docRoot.TrackSerializedObjectValue(serializedObject, OnValueChanged);
        
        // Return the finished inspector UI
        return _docRoot;
    }

    private void OnValueChanged(SerializedObject obj)
    {
        _cardContainer.LoadCard();
    }

}
