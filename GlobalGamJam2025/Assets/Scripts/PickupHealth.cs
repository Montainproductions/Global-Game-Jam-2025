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
    public GameObject itemToSpawn;
    public GameObject itemSpawnPosition;

    public enum PickUpType
    {
        Hotdog
    }

    [SerializeField] public PickUpType currentPickup;

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
            Instantiate(itemToSpawn, itemSpawnPosition.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }

        healthText.text = currentHealth + "/" + startingHealth;
    }
}