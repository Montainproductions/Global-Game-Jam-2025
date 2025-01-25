using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEffects : MonoBehaviour
{

    public float effectTime;
    public float remainingEffectTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnEnable()
    {
        remainingEffectTime = effectTime;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (remainingEffectTime > 0)
        {
            remainingEffectTime -= Time.deltaTime;
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }
}
