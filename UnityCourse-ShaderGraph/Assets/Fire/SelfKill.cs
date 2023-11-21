using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class SelfKill : MonoBehaviour
{

    [SerializeField] private VisualEffect _effect;
    [SerializeField] private float _selfKillTime = 3.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DoSelfKill());
    }

    // Update is called once per frame
    void LateUpdate()
    {

        
    }

    private IEnumerator DoSelfKill()
    {
        
        yield return new WaitForSeconds(_selfKillTime);
        _effect.Stop();
        _effect.SetBool("ImminentDeath", true);

        yield return new WaitUntil(() => _effect.aliveParticleCount <= 0);
        Destroy(gameObject);
        
    }
}
