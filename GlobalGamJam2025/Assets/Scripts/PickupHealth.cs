using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PickupHealth : MonoBehaviour
{
    public float startingHealth;
    public float currentHealth;

    public Canvas pickupCanvas;
    public TextMeshProUGUI healthText;


    void Start()
    {
        currentHealth = startingHealth;
        UpdateHealth();
    }

    private void Update()
    {

    }

    public void UpdateHealth()
    {

        if (currentHealth < 1)
        {
            currentHealth = 0;
            Destroy(this.gameObject);
        }

        healthText.text = currentHealth + "/" + startingHealth;

    }

}