using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Sc_Health : MonoBehaviour
{
    public float startingHealth;
    public float currentHealth;

    public float currentInflation;
    public float maxInflation;

    public Canvas enemyCanvas;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI inflationText;


    void Start()
    {
        currentHealth = startingHealth;
        UpdateHealth();
    }

    private void Update()
    {

    }

    public void UpdateHealth(){
       
        if(currentHealth < 1){
            currentHealth = 0;
            Destroy(this.gameObject);

            //death animation
        }

        if (currentInflation >= maxInflation)
        {
            //inflate
        }

        healthText.text = currentHealth + "/" + startingHealth;
        inflationText.text = currentInflation + "/" + maxInflation;
    }
}
