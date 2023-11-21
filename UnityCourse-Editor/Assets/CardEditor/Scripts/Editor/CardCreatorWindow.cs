using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CardCreatorWindow : EditorWindow
{
    
    private SO_Card _currentSoCard;
    private CardContainer _cardContainer;
    private SO_Card _soCardModel;
    
    [MenuItem("CardCreator/CardCreatorWindow")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(CardCreatorWindow));
    }

    void OnGUI()
    {

        
        // The actual window code goes here
        if (GUILayout.Button("Load Card"))
            LoadCard();

        if (GUILayout.Button("Reset"))
            ResetCard();

        if (GUILayout.Button("Save"))
            SaveCard();

        if (GUILayout.Button("Save as"))
            SaveCardAs();
        
        GUILayout.Label("Folder");
        GUILayout.Label("File name");
        
    }

    private void SaveCardAs()
    {
        throw new System.NotImplementedException();
    }

    private void SaveCard()
    {
        throw new System.NotImplementedException();
    }

    private void ResetCard()
    {
        throw new System.NotImplementedException();
    }

    private void LoadCard()
    {
        if (_cardContainer!=null && _soCardModel!=null)
        {
            Instantiate<CardContainer>(_cardContainer);
            _cardContainer.LoadCard();
        }
    }
    
    
    
    
}
