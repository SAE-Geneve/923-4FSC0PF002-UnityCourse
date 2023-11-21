using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarkovTextGenerator : MonoBehaviour
{

    private readonly MarkovDictionnary _markovDictionary = new MarkovDictionnary();
    [SerializeField] private Text _text;

    // Start is called before the first frame update
    void Start()
    {
        _text.text = "";

        _markovDictionary.AddLink("R", "S", 2f);
        _markovDictionary.AddLink("R", "R", 1f);
        
        _markovDictionary.AddLink("S", "R", 1f);
        _markovDictionary.AddLink("S", "S", 1f);
        _markovDictionary.AddLink("S", "[End]", 0.5f);
        _markovDictionary.Init();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Next()
    {
        _text.text += _markovDictionary.Next();
    }
}
