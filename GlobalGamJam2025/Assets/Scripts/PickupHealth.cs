using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PickupHealth : MonoBehaviour
{
    public float startingHealth;
    public float currentHealth;
    public float currentSpeed;

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

     void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - currentSpeed * Time.deltaTime);
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