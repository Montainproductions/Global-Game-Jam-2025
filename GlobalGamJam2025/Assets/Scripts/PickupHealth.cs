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
        Hotdog,
        Pretzal,
        Pickbundle,
        Cactus0,
        Cactus1
    }

    [SerializeField] public PickUpType currentPickup;

    private void OnEnable()
    {
        currentHealth = startingHealth;
        UpdateHealth();
    }
    void Start()
    {

    }

    void Update()
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