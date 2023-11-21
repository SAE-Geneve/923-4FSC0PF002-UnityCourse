using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MarkovLink
{

    public MarkovLink(string text, float weight)
    {
        _text = text;
        _weight = weight;
    }
    
    private string _text;
    private float _weight;

    public string Text => _text;
    public float Weight => _weight;
}


public class MarkovDictionnary
{

    private readonly List<KeyValuePair<string , MarkovLink>> _links = new List<KeyValuePair<string , MarkovLink>>();
    private string _lastKey;

    public void AddLink(string key, string linkKey, float linkWeight)
    {
        _links.Add(new KeyValuePair<string, MarkovLink>(key, new MarkovLink(linkKey, linkWeight)));
    }

    public void Init()
    {
        _lastKey = _links.ElementAt(Random.Range(0, _links.Count())).Value.Text;
    }

    public string Next()
    {
        string result = _lastKey;
        
        List<KeyValuePair<string, MarkovLink>> availableLinks = _links.Where(l => l.Key == _lastKey).OrderBy(l => l.Value.Weight).ToList();

        float sumWeight = availableLinks.Sum(l => l.Value.Weight);
        float rng = Random.Range(0.0f, sumWeight);
        float rngWeightSum = 0f;
        MarkovLink electedLink = new MarkovLink("n/a", 0);
        
        foreach (var link in availableLinks)
        {
            electedLink = link.Value;
            rngWeightSum += link.Value.Weight;

            if (rng <= rngWeightSum)
            {
                _lastKey = electedLink.Text;
                break;
            }            
        }

        _lastKey = electedLink.Text;
        
        return result;

    }

}
